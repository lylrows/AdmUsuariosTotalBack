﻿namespace HumanManagement.Domain.Common
{
    public class PaginationEntity
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalRows { get; set; }
    }
}
