using DemoButtons;
using Grpc.Core;
using GrpcServer.Protos;

namespace GrpcServer.Services
{
    public class SignatureService : WacomSignature.WacomSignatureBase
    {
        private DemoButtonsForm demoForm;
 

        private readonly ILogger<SignatureService> _logger;
        public SignatureService(ILogger<SignatureService> logger)
        {
            _logger = logger;

            demoForm = new DemoButtonsForm();

        }
        public override Task<InitializeWacomResponse> InitializeWacomDevice(InitializeWacomRequest request, ServerCallContext context)
        {
            var response = new InitializeWacomResponse();
         /*   bool isInitialized = */
            try
            {
                demoForm.button1_Click();
                /*              if (isInitialized)
                              {
                                  Console.WriteLine("Sucess");
                                  IsDeviceInitialized = true;
                                  response.Success = true;

                              }
                              else
                              {
                                  Console.WriteLine("Init failed");
                                  response.Success = false;
                                  response.ErrorMessage = "Initialization Failed";
                              }*/
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;

            }
            return Task.FromResult(response);

        }
    }
}
