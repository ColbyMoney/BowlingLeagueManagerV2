namespace BowlingLeagueManagerV2Backend.DTOs
{
    public class DtoService
    {
        private readonly DtoRepository _dtoRepository;

        public DtoService(DtoRepository dtoRepository)
        {
            _dtoRepository = dtoRepository;
        }

        public async Task<IEnumerable<LeagueDetailsDto>> GetLeagueDetailsByIdAsync(long leagueId)
        {
            var leagueDetails = await _dtoRepository.GetLeagueDetailsByIdAsync(leagueId);
            if (leagueDetails == null)
            {
                throw new Exception($"Bowler not found with id: {leagueId}");
            }
            return leagueDetails;
        }
    }
}
