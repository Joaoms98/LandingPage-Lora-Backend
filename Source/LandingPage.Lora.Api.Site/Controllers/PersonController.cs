using AutoMapper;
using FluentValidation;
using LandingPage.Lora.Api.DTOs;
using LandingPage.Lora.Api.Site.FormRequest;
using LandingPage.Lora.Api.Site.Resources;
using LandingPage.Lora.Domain.DTOs.Inputs;
using LandingPage.Lora.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace LandingPage.Lora.Api.Site;

[ApiController]
[Route("genre")]
public class PersonController : ControllerBase
{
    protected readonly IMapper _mapper;

    public PersonController(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Register new user
    /// </summary>
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JsonResponse<PersonResource>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(JsonResponse<object>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(JsonResponse<object>))]
    public async Task<JsonResponse<PersonResource>> CreateMessage(
        [FromServices] RegisterPersonUseCase useCase,
        [FromBody] PersonRegisterFormRequest payload)
    {
        JsonResponse<PersonResource> response = new JsonResponse<PersonResource>();

        PersonRegisterFormRequestValidator validator = new PersonRegisterFormRequestValidator();

        await validator.ValidateAndThrowAsync(payload);

        var input = new PersonRegisterInput()
        {
            Name = payload.Name,
            Email = payload.Email,
            OptinMarket = payload.OptinMarket,
            OptinTerms = payload.OptinTerms,
        };

        var person = await useCase.Execute(input);

        response.Data = _mapper.Map<PersonResource>(person);
        response.StatusCode = StatusCodes.Status200OK;
        response.Message = ReasonPhrases.GetReasonPhrase(StatusCodes.Status200OK);
        HttpContext.Response.StatusCode = StatusCodes.Status200OK;

        return response;
    }
}