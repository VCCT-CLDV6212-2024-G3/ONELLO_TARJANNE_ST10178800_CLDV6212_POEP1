using Microsoft.AspNetCore.Mvc;

namespace ONELLOTARJANNEST10178800CLDV6212POEPART1.Controllers
{
    public class FunctionController : Controller
    {
        private readonly AzureFunctionService _azureFunctionService;

        public FunctionController(AzureFunctionService azureFunctionService)
        {
            _azureFunctionService = azureFunctionService;
        }

        [HttpPost]
        public async Task<IActionResult> StoreData(string tableName, string partitionKey, string rowKey, string data)
        {
            var result = await _azureFunctionService.StoreTableInfo(tableName, partitionKey, rowKey, data);
            TempData["Result"] = result;  
            return RedirectToAction("Index", "Home"); 
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlob(IFormFile file, string containerName, string blobName)
        {
            if (file != null && !string.IsNullOrWhiteSpace(containerName) && !string.IsNullOrWhiteSpace(blobName))
            {
                using var stream = file.OpenReadStream();
                var result = await _azureFunctionService.UploadBlob(containerName, blobName, stream);
                TempData["Result"] = result;  
                return RedirectToAction("Index", "Home"); 
            }

            return BadRequest("File, container name, and blob name must be provided.");
        }

        [HttpPost]
        public async Task<IActionResult> AddQueueMessage(string queueName, string message)
        {
            var result = await _azureFunctionService.ProcessQueueMessage(queueName, message);
            TempData["Result"] = result;  
            return RedirectToAction("Index", "Home"); 
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, string shareName, string fileName)
        {
            if (file != null && !string.IsNullOrWhiteSpace(shareName) && !string.IsNullOrWhiteSpace(fileName))
            {
                using var stream = file.OpenReadStream();
                var result = await _azureFunctionService.UploadFile(shareName, fileName, stream);
                TempData["Result"] = result;  
                return RedirectToAction("Index", "Home"); 
            }

            return BadRequest("File, share name, and file name must be provided.");
        }
    }
}
