﻿namespace Business.DTOs.Response.Manager;

public class DeletedManagerResponse
{
    public int Id { get; set; }
    public Guid ManagerId { get; set; }
    public int ManagerCode { get; set; }
    public bool IsActive { get; set; }
}