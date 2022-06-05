using SistabizApp_New.Helper;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService
    {

        public List<CommanViewModel> GetBookmarkList(int typeid, int memberid)
        {
            switch (typeid)
            {
                case (int)Categories.DigitalLibrary:
                    return _entityDbContext.TblDigitalLibraryBookmark.Where(r => r.MemberId == memberid).Select(e => new CommanViewModel
                    {
                        BookmarkId = e.BookmarkId,
                        TypeId = e.DigitalLibrryId
                    }).ToList();

                case (int)Categories.FundingResource:
                    return _entityDbContext.TblFundingBookmark.Where(r => r.MemberId == memberid).Select(e => new CommanViewModel
                    {
                        BookmarkId = e.BookmarkId,
                        TypeId = e.FundingId
                    }).ToList();

                case (int)Categories.NetworkDirectory:
                    return _entityDbContext.TblBookMark.Where(r => r.BookmarkBy == memberid).Select(e => new CommanViewModel
                    {
                        BookmarkId = e.BookmarkId,
                        TypeId = e.BookmarkTo
                    }).ToList();

                case (int)Categories.PinkTable:
                    return _entityDbContext.TblPostBookMark.Where(r => r.MemberId == memberid).Select(e => new CommanViewModel
                    {
                        BookmarkId = e.BookmarkId,
                        TypeId = e.PostId
                    }).ToList();

                case (int)Categories.Group:
                    return _entityDbContext.TblGroupBookmarks.Where(r => r.MemberId == memberid).Select(e => new CommanViewModel
                    {
                        BookmarkId = e.BookmarkId,
                        TypeId = e.GroupId
                    }).ToList();

                case (int)Categories.GroupAttachment:
                    return _entityDbContext.TblAttachmentBookmark.Where(r => r.MemberId == memberid).Select(e => new CommanViewModel
                    {
                        BookmarkId = e.BookmarkId,
                        TypeId = e.AttachmentId
                    }).ToList();
                case (int)Categories.Events:
                    return _entityDbContext.TblEventBookmark.Where(r => r.MemberId == memberid).Select(e => new CommanViewModel
                    {
                        BookmarkId = e.BookmarkId,
                        TypeId = e.EventId
                    }).ToList();

                default:
                    return null;
            }
        }
    }
}
