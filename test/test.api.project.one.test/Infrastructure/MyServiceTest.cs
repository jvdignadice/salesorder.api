//using FakeItEasy;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using static test.api.project.one.test.Infrastructure.MyServiceTest;

//namespace test.api.project.one.test.Infrastructure
//{
//        public class MyServiceTests
//        {
//            [Fact]
//            public async Task UpsertBatch_ShouldAddOrUpdateEntities()
//            {
//                // Arrange
//                var existingPizza = new Pizza { Id = 1, Name = "Margherita" };
//                var newPizza = new Pizza { Id = 2, Name = "Pepperoni" };
//                var updatedPizza = new Pizza { Id = 1, Name = "Updated Margherita" };

//                var fakeSet = A.Fake<DbSet<Pizza>>(options => options.Implements(typeof(IQueryable<Pizza>)));
//                var fakeDb = A.Fake<MyDbContext>();

//                var data = new List<Pizza> { existingPizza }.AsQueryable();

//                // Setup IQueryable for DbSet
//                A.CallTo(() => fakeSet.Provider).Returns(data.Provider);
//                A.CallTo(() => fakeSet.Expression).Returns(data.Expression);
//                A.CallTo(() => fakeSet.ElementType).Returns(data.ElementType);
//                A.CallTo(() => fakeSet.GetEnumerator()).Returns(data.GetEnumerator());

//                A.CallTo(() => fakeDb.Set<Pizza>()).Returns(fakeSet);
//                A.CallTo(() => fakeDb.SaveChangesAsync(A<CancellationToken>._)).Returns(Task.FromResult(1));

//                var service = new MyService(fakeDb);

//                var batch = new List<Pizza> { updatedPizza, newPizza };

//                var keyProp = typeof(Pizza).GetProperty(nameof(Pizza.Id))!;

//                // Act
//                await service.UpsertBatch(batch, keyProp);

//                // Assert
//                A.CallTo(() => fakeSet.Add(A<Pizza>.That.Matches(p => p.Id == 2 && p.Name == "Pepperoni"))).MustHaveHappenedOnceExactly();

//                Assert.Equal("Updated Margherita", existingPizza.Name);
//            }
//        }

//        // Your service containing UpsertBatch
//        public class MyService
//        {
//            private readonly MyDbContext _db;

//            public MyService(MyDbContext db)
//            {
//                _db = db;
//            }

//            public async Task UpsertBatch<TEntity>(List<TEntity> batch, PropertyInfo keyProp) where TEntity : class
//            {
//                var set = _db.Set<TEntity>();

//                var keyType = Nullable.GetUnderlyingType(keyProp.PropertyType) ?? keyProp.PropertyType;
//                var typedList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(keyType))!;
//                foreach (var val in batch.Select(b => keyProp.GetValue(b)))
//                    typedList.Add(val);

//                var param = Expression.Parameter(typeof(TEntity), "e");
//                var property = Expression.Property(param, keyProp);

//                var containsMethod = typedList.GetType().GetMethod("Contains", new[] { keyType })!;
//                var valuesExpr = Expression.Constant(typedList);
//                var containsExpr = Expression.Call(valuesExpr, containsMethod, property);

//                var lambda = Expression.Lambda<Func<TEntity, bool>>(containsExpr, param);

//                var existing = await set.Where(lambda).ToListAsync();

//                foreach (var entity in batch)
//                {
//                    var keyValue = keyProp.GetValue(entity);
//                    var match = existing.FirstOrDefault(x => Equals(keyProp.GetValue(x), keyValue));

//                    if (match == null)
//                        set.Add(entity);
//                    else
//                    {
//                        foreach (var p in typeof(TEntity).GetProperties())
//                        {
//                            p.SetValue(match, p.GetValue(entity));
//                        }
//                    }
//                }

//                await _db.SaveChangesAsync();
//            }
//        }

//        // Dummy DbContext
//        public class MyDbContext : DbContext
//        {
//            public virtual DbSet<Pizza> Pizzas { get; set; } = null!;
//        }
//}
