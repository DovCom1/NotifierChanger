using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NotifierChanger.Model.Dto;

public class EventDto
{
    [Required]
    public required Guid SenderId { get; set; }
    [Required]
    public required Guid ReceiverId { get; set; }
    [Required]
    public required string TypeDto { get; set; }

    [JsonExtensionData] 
    public IDictionary<string, JsonElement> AdditionalData { get; set; } = new Dictionary<string, JsonElement>();
}