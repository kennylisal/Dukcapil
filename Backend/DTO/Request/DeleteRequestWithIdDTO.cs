using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.DTO.Request;

public class DeleteRequestWithIdDTO
{
    [Required]
    public required string Id { get; set; }
}
