using MyDummyAPI.DTOs;
using MyDummyAPI.Models;
using MyDummyAPI.Repositories.Interfaces;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Services.Implementations
{
    public class PartnerServices : IPartnerServices
    {
        private readonly IPartnerRepo partnerRepo;
        public PartnerServices(IPartnerRepo partnerRepo)
        {
            this.partnerRepo = partnerRepo;
        }
        public async Task<PartnerDTO> addPartner(PartnerDTO partnerDTO)
        {
            var newPartner = new Partner
            {
                UserId = partnerDTO.UserId,
                PartnershipType = partnerDTO.PartnershipType,
                SharePercentage = partnerDTO.SharePercentage,
                IsMainPartner = partnerDTO.IsMainPartner
            };

            var result = await partnerRepo.addPartner(newPartner);

            return new PartnerDTO
            {
                UserId = result.UserId,
                PartnershipType = result.PartnershipType,
                SharePercentage = result.SharePercentage,
                IsMainPartner = result.IsMainPartner
            };
        }

        public async Task<List<PartnerDTO>> getAllPartner()
        {
            var partners = await partnerRepo.getAllPartner();

            return partners.Select(p => new PartnerDTO
            {
                UserId = p.UserId,
                SharePercentage = p.SharePercentage,
                IsMainPartner = p.IsMainPartner,
                PartnershipType = p.PartnershipType
            }).ToList();
        }
    }
}
