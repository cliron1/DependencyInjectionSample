using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Services {
	public interface IOperationService {
		IOperationTransient TransientOperation { get; }
		IOperationScoped ScopedOperation { get; }
		IOperationSingleton SingletonOperation { get; }
	}

	public class OperationService : IOperationService {
		public IOperationTransient TransientOperation { get; }
		public IOperationScoped ScopedOperation { get; }
		public IOperationSingleton SingletonOperation { get; }

		public OperationService(
			IOperationTransient transientOperation,
			IOperationScoped scopedOperation,
			IOperationSingleton singletonOperation) {

			TransientOperation = transientOperation;
			ScopedOperation = scopedOperation;
			SingletonOperation = singletonOperation;
		}
	}
}