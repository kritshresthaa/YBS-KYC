using Grpc.Core;
using GrpcServer.Protos.Fingerprint;
using System.Text;
using WinformServer;

namespace GrpcServer.Services
{
    public class FingerprintService : Fingerprint.FingerprintBase
    {
        private Byte[] f1;
        private Byte[] f2;
        private Form1 form1;
        private readonly ILogger<FingerprintService> _logger;

        private bool isDeviceInitialized = false;

        public FingerprintService(ILogger<FingerprintService> logger)
        {
            _logger = logger;
            form1 = new Form1();

            // Initialize the device when the service is created (singleton).
            InitializeDevice();
        }

        // Initialization method
        private void InitializeDevice()
        {
            if (!isDeviceInitialized)
            {
                try
                {
                    form1.InitilzingDevice();
                    isDeviceInitialized = true;

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Initialization failed: {ex.Message}");
                }
            }
        }

        public override Task<InitializeResponse> InitializeDevice(InitializeRequest request, ServerCallContext context)
        {
            // Initialization has already been performed, so return a success response.
            var response = new InitializeResponse { Success = true };
            return Task.FromResult(response);
        }



        public override Task<CaptureResponse> CaptureLeftFingerprint(CaptureRequest request, ServerCallContext context)
        {
            var response = new CaptureResponse();

            try
            {
                if (!isDeviceInitialized)
                {
                    response.ErrorMessage = "Fingerprint device is not initialized.";
                    response.Success = false;
                    return Task.FromResult(response);
                }
                else
                {
                    if (f1 == null)
                    {
                        f1 = form1.CaptureAndDisplayImage();
                        if (f1 == null)
                        {
                            response.Success = false;
                            return Task.FromResult(response);
                        }
                        else
                        {
                            response.Success = true;

                            response.FingerprintData = Google.Protobuf.ByteString.CopyFrom(f1);
                            Console.WriteLine("Left fingerprint captured successfully. Place your right finger.");
                        }
                    }
                    else
                    {
                        // Left fingerprint is already captured, so no need to capture it again.
                        response.ErrorMessage = "Left fingerprint is already captured.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return Task.FromResult(response);
        }

        public override Task<CaptureResponse> CaptureRightFingerprint(CaptureRequest request, ServerCallContext context)
        {
            var response = new CaptureResponse();

            try
            {
                if (!isDeviceInitialized)
                {
                    response.ErrorMessage = "Fingerprint device is not initialized.";
                    response.Success = false;
                    return Task.FromResult(response);
                }
                else
                {
                    if (f2 == null)
                    {
                        f2 = form1.CaptureAndDisplayImage();
                        if (f2 == null)
                        {
                            response.Success = false;
                            return Task.FromResult(response);
                        }
                        else
                        {
                            response.Success = true;
                            response.FingerprintData = Google.Protobuf.ByteString.CopyFrom(f2);
                   
                            Console.WriteLine("Right fingerprint captured successfully. Place your right finger.");
                        }
                    }
                    else
                    {
                        // Right fingerprint is already captured, so no need to capture it again.
                        response.ErrorMessage = "Right fingerprint is already captured.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return Task.FromResult(response);
        }
    }
}
