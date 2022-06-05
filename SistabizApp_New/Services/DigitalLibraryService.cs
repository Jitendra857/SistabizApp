using SistabizApp_New.Helper;
using SistabizApp_New.Models;
using SistabizApp_New.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistabizApp_New.Services
{
    public partial class BLLService
    {

        public List<DigitalLibraryViewModel> GetDigitalLibraryList(string search = null)
        {
            
            if (!string.IsNullOrEmpty(search))
            {
                return _entityDbContext.TblDigitalLibrary.Where(a => a.IsDeleted != true && a.Title.Contains(search)).Select(e => new DigitalLibraryViewModel
                {
                    DigitalLibraryId = e.DigitalLibraryId,
                    Title = e.Title,
                    Description = e.Description,
                    Type = e.Type,
                    Price = e.Price,
                    PaymentType = CommanHelper.GetDigitalLibraryPaymentType((int)e.Type),
                    CategoryType = e.CategoryId,
                    CategoryName = e.Category != null ? e.Category.CategoryName : null,
                    CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                    CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                    IsBookmark = e.TblDigitalLibraryBookmark.Count>0 ? true : false,
                    GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.ProfileIcon,
                   CreatedOn=e.CreatedOn,
                    lstDigitalLibraryAttachment = e.TblDigitalLibaryAttachment.Count > 0 ? e.TblDigitalLibaryAttachment.Select(r => new DigitalLibraryAttachmentViewModel
                    {
                        LibraryAttachmentId = r.LibraryAttachmentId,
                        FileName = Constant.livebaseurl + "DigitalLibrary/" + r.FileName


                    }).ToList() : null,

                }).ToList();
            }
            else
            {
                return _entityDbContext.TblDigitalLibrary.Where(a => a.IsDeleted != true).Select(e => new DigitalLibraryViewModel
                {
                    DigitalLibraryId = e.DigitalLibraryId,
                    Title = e.Title,
                    Description = e.Description,
                    Type = e.Type,
                    Price = e.Price,
                    PaymentType = CommanHelper.GetDigitalLibraryPaymentType((int)e.Type),
                    CategoryType = e.CategoryId,
                    CategoryName = e.Category != null ? e.Category.CategoryName : null,
                    CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                    CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                    IsBookmark = e.TblDigitalLibraryBookmark.Count > 0 ? true : false,
                    GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.ProfileIcon,
                    CreatedOn = e.CreatedOn,
                    lstDigitalLibraryAttachment = e.TblDigitalLibaryAttachment.Count > 0 ? e.TblDigitalLibaryAttachment.Select(r => new DigitalLibraryAttachmentViewModel
                    {
                        LibraryAttachmentId = r.LibraryAttachmentId,
                        FileName = Constant.livebaseurl + "DigitalLibrary/" + r.FileName


                    }).ToList() : null
                }).ToList();


            }
        }

        public DigitalLibraryViewModel GetDigitalLibraryDetailsById(int id )
        {

           
                return _entityDbContext.TblDigitalLibrary.Where(a => a.IsDeleted != true && a.DigitalLibraryId==id).Select(e => new DigitalLibraryViewModel
                {
                    DigitalLibraryId = e.DigitalLibraryId,
                    Title = e.Title,
                    Description = e.Description,
                    Type = e.Type,
                    Price = e.Price,
                    PaymentType = CommanHelper.GetDigitalLibraryPaymentType((int)e.Type),
                    CategoryType = e.CategoryId,
                    CategoryName = e.Category != null ? e.Category.CategoryName : null,
                    CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                    CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                    IsBookmark = e.TblDigitalLibraryBookmark.Count > 0 ? true : false,
                    GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.ProfileIcon,
                    CreatedOn = e.CreatedOn,
                  
                    lstDigitalLibraryAttachment = e.TblDigitalLibaryAttachment.Count > 0 ? e.TblDigitalLibaryAttachment.Select(r => new DigitalLibraryAttachmentViewModel
                    {
                        LibraryAttachmentId = r.LibraryAttachmentId,
                        FileName = Constant.livebaseurl + "DigitalLibrary/" + r.FileName,
                        FileUrl=r.FileName


                    }).ToList() : null,

                }).FirstOrDefault();
           
          

          
        }
        public string DigitalLibraryBookmark(DigitalLibraryBookmarkViewModel model)
        {
            TblDigitalLibraryBookmark bookmark = new TblDigitalLibraryBookmark();

            if (model.BookmarkId > 0)
            {
                var result = _entityDbContext.TblDigitalLibraryBookmark.Where(e => e.BookmarkId == model.BookmarkId).FirstOrDefault();

                if (result != null)
                {
                    _entityDbContext.TblDigitalLibraryBookmark.Remove(result);
                    _entityDbContext.SaveChanges();
                    return "Unbookmark";
                }
            }
            else
            {

                bookmark.MemberId = model.MemberId;
                bookmark.CategoryId = model.CategoryId;
                bookmark.DigitalLibrryId = model.DigitalLibraryId;
                _entityDbContext.TblDigitalLibraryBookmark.Add(bookmark);
                _entityDbContext.SaveChanges();
                return "bookmark";
            }
            return Constant.Success;
        }

        public List<DigitalLibraryViewModel> GetDigitalLibraryListByCategory(int category)
        {
           
            return _entityDbContext.TblDigitalLibrary.Where(a => a.IsDeleted != true && a.CategoryId == category).Select(e => new DigitalLibraryViewModel
            {
                DigitalLibraryId = e.DigitalLibraryId,
                Title = e.Title,
                Description = e.Description,
                Type = e.Type,
                Price = e.Price,
                PaymentType = CommanHelper.GetDigitalLibraryPaymentType((int)e.Type),
                CategoryType = e.CategoryId,
                CategoryName = e.Category != null ? e.Category.CategoryName : null,
                CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                IsBookmark = e.TblDigitalLibraryBookmark.Count > 0 ? true : false,
                GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.ProfileIcon,
                CreatedOn = e.CreatedOn,
                lstDigitalLibraryAttachment = e.TblDigitalLibaryAttachment.Count > 0 ? e.TblDigitalLibaryAttachment.Select(r => new DigitalLibraryAttachmentViewModel
                {
                    LibraryAttachmentId = r.LibraryAttachmentId,
                    FileName = Constant.livebaseurl + "DigitalLibrary/" + r.FileName,
                    FileUrl = r.FileName


                }).ToList() : null,


            }).ToList();


        }

        public List<DigitalLibraryViewModel> GetGroupListByFilter(DigitalLibraryFilterViewModel model)
        {


            if (model.IsSaved == false)
            {



                return _entityDbContext.TblDigitalLibrary.Where(a => a.IsDeleted != true && a.CategoryId == model.CategoryId).Select(e => new DigitalLibraryViewModel
                {
                    DigitalLibraryId = e.DigitalLibraryId,
                    Title = e.Title,
                    Description = e.Description,
                    Type = e.Type,
                    Price = e.Price,
                    PaymentType = CommanHelper.GetDigitalLibraryPaymentType((int)e.Type),
                    CategoryType = e.CategoryId,
                    CategoryName = e.Category != null ? e.Category.CategoryName : null,
                    CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                    CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                    IsBookmark = e.TblDigitalLibraryBookmark.Count > 0 ? true : false,
                    GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.ProfileIcon,
                    CreatedOn = e.CreatedOn,
                    lstDigitalLibraryAttachment = e.TblDigitalLibaryAttachment.Count > 0 ? e.TblDigitalLibaryAttachment.Select(r => new DigitalLibraryAttachmentViewModel
                    {
                        LibraryAttachmentId = r.LibraryAttachmentId,
                        FileName = Constant.livebaseurl + "DigitalLibrary/" + r.FileName,
                        FileUrl = r.FileName


                    }).ToList() : null,


                }).ToList();
            }
            else
            {
                var bookmarksdetails = _entityDbContext.TblDigitalLibraryBookmark.Where(e => e.MemberId == model.MemberId && e.CategoryId == model.CategoryId).Select(k => k.DigitalLibrryId).ToList();

               

                return _entityDbContext.TblDigitalLibrary.Where(a => a.IsDeleted != true && bookmarksdetails.Contains(a.DigitalLibraryId)).Select(e => new DigitalLibraryViewModel
                {
                    DigitalLibraryId = e.DigitalLibraryId,
                    Title = e.Title,
                    Description = e.Description,
                    Type = e.Type,
                    Price = e.Price,
                    PaymentType = CommanHelper.GetDigitalLibraryPaymentType((int)e.Type),
                    CategoryType = e.CategoryId,
                    CategoryName = e.Category != null ? e.Category.CategoryName : null,
                    CreateByName = e.CreatedByNavigation != null ? e.CreatedByNavigation.FirstName + " " + e.CreatedByNavigation.LastName : null,
                    CreateByProfile = e.CreatedByNavigation != null ? Constant.livebaseurl + "Profiles/" + e.CreatedByNavigation.ProfileImage : null,
                    IsBookmark = e.TblDigitalLibraryBookmark.Count > 0 ? true : false,
                    GroupIconPath = Constant.livebaseurl + "GroupIcon/" + e.ProfileIcon,
                    CreatedOn = e.CreatedOn,
                    lstDigitalLibraryAttachment = e.TblDigitalLibaryAttachment.Count > 0 ? e.TblDigitalLibaryAttachment.Select(r => new DigitalLibraryAttachmentViewModel
                    {
                        LibraryAttachmentId = r.LibraryAttachmentId,
                        FileName = Constant.livebaseurl + "DigitalLibrary/" + r.FileName,
                        FileUrl = r.FileName


                    }).ToList() : null,


                }).ToList();
            }



        }

        public List<DigitalLibraryCategoryViewModel> GetCategoryList()
        {
            return _entityDbContext.TblDigitalLibraryCategory.Select(e => new DigitalLibraryCategoryViewModel
            {
                CategoryId = e.CategoryId,
                CategoryName = e.CategoryName
            }).ToList();
        }

        public long ManageDigitalLibrary(DigitalLibraryViewModel model)
        {
            TblDigitalLibrary digitallibrary = new TblDigitalLibrary();
            if (model.DigitalLibraryId > 0)
                digitallibrary = GetDigitalLibraryById((int)model.DigitalLibraryId);

            digitallibrary.Title = model.Title;
            digitallibrary.Description = model.Description;
            digitallibrary.Type = model.Type;
            digitallibrary.Price = model.Price;
            digitallibrary.CreatedBy = model.CreatedBy;
            digitallibrary.CreatedOn = DateTime.Now;
            digitallibrary.IsDeleted = false;
            digitallibrary.CategoryId = model.CategoryType;
            digitallibrary.ProfileIcon = model.GroupIconPath;


            if (model.DigitalLibraryId == 0)
                _entityDbContext.TblDigitalLibrary.Add(digitallibrary);

            _entityDbContext.SaveChanges();
            return digitallibrary.DigitalLibraryId;
        }


        public string UploadDigitalLibraryAttachment(List<TblDigitalLibaryAttachment> attchment)
        {

            _entityDbContext.TblDigitalLibaryAttachment.AddRange(attchment);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }


        public string RemoveDigitalLibrary(int digitallibraryid)
        {
            var digitallibrary = GetDigitalLibraryById(digitallibraryid);
            if (digitallibrary != null)
            {
                digitallibrary.IsDeleted = true;
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }

        public TblDigitalLibrary GetDigitalLibraryById(int digitallibraryid)
        {
            return _entityDbContext.TblDigitalLibrary.Where(e => e.DigitalLibraryId == digitallibraryid).FirstOrDefault();
        }

    }
}
