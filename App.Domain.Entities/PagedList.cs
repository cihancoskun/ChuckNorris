using System;
using System.Collections.Generic;

namespace App.Domain.Entities
{
    public class PagedList<TEntity> where TEntity : BaseEntity
    {
        public int CurrentPageNumber { get; set; }
        public int Size { get; set; }
        public long TotalCount { get; set; }
        public int TotalPageCount { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public List<TEntity> Items { get; set; }

        public PagedList(int pageNumber, int pageSize, long totalCount, List<TEntity> source)
        {
            Items = new List<TEntity>();

            if (source != null)
                Items.AddRange(source);

            CurrentPageNumber = pageNumber;
            Size = pageSize;
            TotalCount = totalCount;
            TotalPageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            HasPreviousPage = CurrentPageNumber > 0;
            HasNextPage = CurrentPageNumber < TotalPageCount;
        }
    }
}
