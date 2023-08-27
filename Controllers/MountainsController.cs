
using System.Runtime.CompilerServices;
using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using mountains.Models;

[ApiController]
[Route("api/[controller]")]
public class MountainsController: ControllerBase {
    
    private readonly MountainsService _mountainsService;

    public MountainsController(MountainsService mountainsService) => _mountainsService = mountainsService;

    //Get All mountains
    [HttpGet]
    public async Task<List<Mountain>> GetMountains(MountainsService _mountainsService){
        try
        {
            return await _mountainsService.GetAsync();
        }
        catch (Exception ex)
        {
            
            throw;
        }
        
    }

    //Get single Mountain
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Mountain>> GetMountain(MountainsService _mountainsService, string id){
        
        var mountain = await _mountainsService.GetAsync(id);
        if(mountain is null) {
            //404 not found
            return NotFound();
        }
        return mountain;
    }

    [HttpGet("{selectedCountry}")]
    public async Task<List<Mountain>> GetMountainsByCountry(MountainsService _mountainService, string selectedCountry){

        var mountains = await _mountainService.GetByCountryAsync(selectedCountry);
        
        if(mountains.Count == 0) return new List<Mountain>();

        return mountains;
    }

    //endpoint api/mountains/altitude/whatever altitude
    [HttpGet("altitude/{minAltitude}")]
    public async Task<List<Mountain>> GetMountainsByAltitude(MountainsService _mountainsService, double minAltitude){
        var mtns = await _mountainsService.GetAsync(minAltitude);
        
        if(mtns.Count == 0){
            return new List<Mountain>();
        }


        return mtns;

    }

    [HttpPost]
    public async Task<IActionResult> PostMountain(Mountain newMountain){
        
        await _mountainsService.CreateAsync(newMountain);
        // 201 created
        return CreatedAtAction(nameof(GetMountain), new {id = newMountain.Id}, newMountain);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> PutMountain(string id, Mountain updatedMountain){
        
        var mountain = _mountainsService.GetAsync(id);

        if(mountain is null){
            //404 notfound
            return NotFound();
        }
        
        await _mountainsService.UpdateAsync(id, updatedMountain);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> DeleteMountain(string id){

        var mountain = await _mountainsService.GetAsync(id);

        if(mountain is null){
            //404 not found
            return NotFound();
        }

        await _mountainsService.DeleteAsync(id);

        return NoContent();
    }
}