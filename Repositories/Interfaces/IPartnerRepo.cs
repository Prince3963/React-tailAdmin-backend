using MyDummyAPI.Models;

namespace MyDummyAPI.Repositories.Interfaces
{
    public interface IPartnerRepo
    {
        Task<List<Partner>> getAllPartner();
        Task<Partner> addPartner(Partner partner);
        Task<Partner> getPartnerById(int id);
    }
}
