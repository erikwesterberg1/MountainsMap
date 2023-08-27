using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using mountains.Models;

[ApiController]
[Route("api/[controller]")]
public class ClimbersController {

    public readonly ClimbersService _climbersService;
    public ClimbersController(ClimbersService climbersService)
    {
        _climbersService = climbersService;
    }

    public async Task<List<Climber>> GetAllClimbers(ClimbersService climbersService){
        try
        {
            return await climbersService.GetAsync();
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
