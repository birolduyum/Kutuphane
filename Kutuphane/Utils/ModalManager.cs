using Blazored.Modal;
using Blazored.Modal.Services;
using Kutuphane.CustomComponents.ModalComponents;

namespace Kutuphane.Utils
{
    public class ModalManager
    {
        private readonly IModalService modalService;
        public ModalManager(IModalService ModalService)
        {
            modalService = ModalService;  
        }

        public async Task ShowMessageAsync(string Title, string Message, int Duration = 0)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);
            var modalRef = modalService.Show<ShowMessagePopupComponent>(Title, mParams);
            if (Duration > 0)
            {
                await Task.Delay(Duration);
                modalRef.Close(); 
            }
        }

        public async Task<bool> ConfirmationAsync(string Title, string Message)
        {
            ModalParameters mParams = new ModalParameters();
            mParams.Add("Message", Message);

            var modalRef = modalService.Show<ConfirmationPopupComponent>(Title, mParams);
            var modalResult = await modalRef.Result;
            
            return !modalResult.Cancelled; 

        }


    }
}
