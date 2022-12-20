using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.UnitTesting
{
    public abstract class ApiUnitTestBase<T> : IDisposable
    {
        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public T Target { get; set; }

        /// <summary>
        /// Gets or sets the fixture.
        /// </summary>
        protected IFixture Fixture { get; set; }

        /// <summary>
        ///  Creates the target under test and mocks. Called prior to each test.
        /// </summary>
        public abstract void TestSetup();

        /// <summary>
        /// Tear-down for each test in the fixture.
        /// </summary>
        public abstract void TestTearDown();

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiUnitTestBase<T>" /> class.
        /// </summary>
        protected ApiUnitTestBase()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            TestSetup();
        }

        /// <summary>
        /// Creates and injects a Mock
        /// </summary>
        /// <typeparam name="TInterface">The type of mock to create</typeparam>
        /// <returns>A mock</returns>
        public Mock<TInterface> CreateAndInjectMock<TInterface>()
            where TInterface : class
        {
            var mock = new Mock<TInterface>(MockBehavior.Strict);
            Fixture.Inject(mock);
            return mock;
        }

        // To detect redundant calls
        private bool disposedValue = false;

        /// <summary>
        /// Disposing objects.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    TestTearDown();
                    // TODO: dispose managed state (managed objects).
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
    }
}
