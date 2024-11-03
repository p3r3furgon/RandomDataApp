using B1Task1.UseCases.AddRandomDataFromFile;
using B1Task1.UseCases.AddRandomDataRows;
using B1Task1.UseCases.CombineRandomDataFiles;
using B1Task1.UseCases.DeleteAllRandomData;
using B1Task1.UseCases.DeleteRandomDataById;
using B1Task1.UseCases.GenerateRandomDataFiles;
using B1Task1.UseCases.GetRandomData;
using B1Task1.UseCases.GetRandomDataStatistics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace B1Task1.Controllers
{
    /// <summary>
    /// Контроллер для работы случайных данных
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RandomDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public RandomDataController(IMediator mediator)
        { 
            _mediator = mediator;
        }

        /// <summary>
        /// Генерирование файлов с случайными данными
        /// </summary>
        /// <param name="request">Содержит свойства FileNumber(количество генерируемых файлов) 
        /// и LineNumber(количество строк с данными в генерируемом файле)</param>
        /// <returns>Возвращает успешность выполнения запроса(IsSuccess). В случае IsSuccess = false, 
        /// свойство Message содержит строку с описанием ошибки</returns>
        [HttpPost("generate")]
        public async Task<IActionResult> GenerateRandomDataFiles(GenerateRandomDataFilesRequest request)
        {
            var response = await _mediator.Send(request);
            if (!response.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, response);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Получение списка элементов типа RandomDataEntry из БД
        /// </summary>
        /// <param>Содержит переменные page и pageSize, используемые для пагинации</param>
        /// <returns>Возвращает успешность выполнения запроса(IsSuccess) и список объектов RandomDataEntry. В случае IsSuccess = false, 
        /// свойство Message содержит строку с описанием ошибки</returns>
        [HttpGet]
        public async Task<IActionResult> GetRandomData(int page, int pageSize)
        {
            var response = await _mediator.Send(new GetRandomDataRequest(page, pageSize));
            if (!response.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, response);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Получение статистических данных для всех элементов из БД
        /// </summary>
        /// <returns>Возвращает успешность выполнения запроса(IsSuccess), сумму всех целочисленных значений(Sum) и медиану всех дробных чисел(Median). 
        /// В случае IsSuccess = false, свойство Message содержит строку с описанием ошибки</returns>
        [HttpGet("statistics")]
        public async Task<IActionResult> GetRandomDataStatisticValues()
        {
            var response = await _mediator.Send(new GetRandomDataStatisticsRequest());
            if (!response.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, response);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Комбинирование двух файлов
        /// </summary>
        /// <param name="request">Содержит свойства File1, File2, OutputFileName и Filter. 
        /// OutputFileName - имя файла - результата комбинации файлов File1 и File2, 
        /// Filter - фильтр строк для удаления (англ. язык).</param>
        /// <returns>Возвращает успешность выполнения запроса (IsSuccess). В случае IsSuccess = false, 
        /// свойство Message содержит строку с описанием ошибки.</returns>
        [HttpPost("combine")]
        public async Task<IActionResult> CombineFilesData([FromForm] CombineRandomDataFilesRequest request)
        {
            var response = await _mediator.Send(request);
            if (!response.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, response);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Добавление данных из файла в БД.
        /// </summary>
        /// <param name="request">Содержит свойство File - файл, данные которого добавляются в БД </param>
        /// <returns>Возвращает успешность выполнения запроса(IsSuccess). В случае IsSuccess = false, 
        /// свойство Message содержит строку с описанием ошибки</returns>
        [HttpPost]
        public async Task<IActionResult> AddRandomData([FromForm] AddRandomDataFromFileRequest request)
        {
            var response = await _mediator.Send(request);
            if (!response.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, response);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Добавление данных в БД.
        /// </summary>
        /// <param name="request">Содержит свойство RandowDataRows - список строк</param>
        /// <returns>Возвращает успешность выполнения запроса(IsSuccess). В случае IsSuccess = false, 
        /// свойство Message содержит строку с описанием ошибки</returns>
        [HttpPost("test")]
        public async Task<IActionResult> AddRandomData(AddRandomDataRowsRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, response);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Удаляет все данные из БД.
        /// </summary>
        /// <returns>Возвращает успешность выполнения запроса(IsSuccess). В случае IsSuccess = false, 
        /// свойство Message содержит строку с описанием ошибки</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteAllRandomData()
        {
            var response = await _mediator.Send(new DeleteAllRandomDataRequest());

            if (!response.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, response);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        /// <summary>
        /// Удаляет запись из БД по id.
        /// </summary>
        /// <param name="id">ID удаляемой записи</param>
        /// <returns>Возвращает успешность выполнения запроса(IsSuccess). В случае IsSuccess = false, 
        /// свойство Message содержит строку с описанием ошибки</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRandomData(int id)
        {
            var response = await _mediator.Send(new DeleteRandomDataByIdRequest(id));

            if (!response.IsSuccess)
                return StatusCode(StatusCodes.Status400BadRequest, response);

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
