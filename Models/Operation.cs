using System;
using DependencyInjectionSample.Interfaces;

namespace DependencyInjectionSample.Classes {
	public class Operation: IOperationTransient, IOperationScoped, IOperationSingleton {
		public Guid OperationId { get; } = Guid.NewGuid();
	}
}