using LibraryData;
using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryService
{
    public class LibraryAssetService : ILibraryAsset
    {
        public LibraryAssetService(LibraryContext _context)
        {
            Context = _context;
        }

        public LibraryContext Context { get; }

        public void Add(LibraryAsset newAsset)
        {
            Context.Add(newAsset);
            Context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return Context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.BranchLocation);
        }

        public LibraryAsset GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).BranchLocation;
        }

        public string GetDeweyIndex(int id)
        {
            if (Context.Books.Any(book => book.Id == id))
            {
                return Context.Books.FirstOrDefault(book => book.Id == id).DeweyIndex;
            }

            return "";
        }

        public string GetIsbn(int id)
        {
            if (Context.Books.Any(book => book.Id == id))
            {
                return Context.Books.FirstOrDefault(book => book.Id == id).ISBN;
            }

            return "";
        }

        public string GetTitle(int id)
        {
            return Context.LibraryAssets
                .FirstOrDefault(asset => asset.Id == id)
                .Title;
        }

        public string GetType(int id)
        {
            var book = Context.LibraryAssets.OfType<Book>()
                .Where(b => b.Id == id);

            return book.Any() ? "Book" : "Video";
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = Context.LibraryAssets.OfType<Book>()
                .Where(asset => asset.Id == id).Any();

            var isVideo = Context.LibraryAssets.OfType<Video>()
                .Where(asset => asset.Id == id).Any();

            return isBook ?
                Context.Books.FirstOrDefault(book => book.Id == id).Author :
                Context.Videos.FirstOrDefault(video => video.Id == id).Director
                ?? "Unknown";
        }
    }
}
