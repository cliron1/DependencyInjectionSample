using DependencyInjectionSample.Classes;
using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionSample.Controllers {
	public class OperationsController : Controller {
		private readonly IOperationTransient _transientOperation;
		private readonly IOperationScoped _scopedOperation;
		private readonly IOperationSingleton _singletonOperation;
		
		private readonly IOperationService _service;

		public OperationsController(
			IOperationTransient transientOperation,
			IOperationScoped scopedOperation,
			IOperationSingleton singletonOperation,

			IOperationService operationService
			) {

			_transientOperation = transientOperation;
			_scopedOperation = scopedOperation;
			_singletonOperation = singletonOperation;
			_service = operationService;

		}

		public IActionResult Index() {
			// viewbag contains controller-requested services
			ViewBag.Transient = _transientOperation;
			ViewBag.Scoped = _scopedOperation;
			ViewBag.Singleton = _singletonOperation;

			return View(_service);
		}
	}
}