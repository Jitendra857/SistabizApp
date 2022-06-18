using Microsoft.EntityFrameworkCore;
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

        public List<EventResponseViewModel> GetEventList()
        {
            var eventdetails = new List<TblEvent>();

            eventdetails = _entityDbContext.TblEvent.Where(e => e.IsDeleted != true)
                .Include(s=>s.TblEventAttachment)
                 .Include(s => s.TblEventBookmark)
                  .Include(s => s.TblEventRegisterMember)
                   .ThenInclude(s => s.RegisterMember)
                .ToList();
            return eventdetails.OrderByDescending(r=>r.EventId).Select(e => new EventResponseViewModel
            {
                EventId=e.EventId,
                Title = e.Title,
                EventName = e.EventName,
                VenueName = e.VenueName,
                Address = e.Address,
                City = e.City,
                Country = e.Country,
                State = e.State,
                PostalCode = e.PostalCode,
                Phone = e.Phone,
                Website = e.Website,
                OrganizerName = e.OrganizerName,
                OrganizerPhone = e.OrganizerPhone,
                OrganizerWebsite = e.OrganizerWebsite,
                OrganizerEmail = e.OrganizerEmail,
                EventWebsite = e.EventWebsite,
                EventCost = e.EventCost,
                EventStatus = e.EventStatus,
                //EventStatusTrack = CommanHelper.GetEventStatus((int)e.EventStatus),
                EventDate = e.EventDate,
               StartTime=e.StartTime,
                EventEndDate = e.EventEndDate,
                EndTime=e.EndTime,
                Description = e.Description,
                CreatedOn = e.CreatedOn,
                CreatedBy = e.CreatedBy,
                IsBookmark = e.TblEventBookmark.Count > 0 ? true : false,
                lstEventAttachment = e.TblEventAttachment.Count > 0 ? e.TblEventAttachment.Select(r => new EventAttachment
                {
                    EventAttachmentId = r.EventAttachmentId,
                    EventId = r.EventId,
                    FileName = Constant.livebaseurl + "Events/" + r.FileName,
                }).ToList() : null,
                 lstEventJoinMembers = e.TblEventRegisterMember.Count > 0 ? e.TblEventRegisterMember.Select(t => new EventJoinMemberViewModel
                {
                    MemberProfile = t.RegisterMember != null ? Constant.livebaseurl + "Profiles/" + t.RegisterMember.ProfileImage : null,
                    MemberName = t.RegisterMember != null ? t.RegisterMember.FirstName + " " + t.RegisterMember.LastName : null
                }).ToList() : null,
                Attendee =e.TblEventRegisterMember.Count,
               // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).ToList();

           
        }

        public List<EventResponseViewModel> SearchEventList(string search)
        {
            var eventdetails = new List<TblEvent>();
            eventdetails = _entityDbContext.TblEvent.Where(r => r.IsDeleted != true && r.EventName.Contains(search))
                .Include(s => s.TblEventAttachment)
                 .Include(s => s.TblEventBookmark)
                  .Include(s => s.TblEventRegisterMember)
                   .ThenInclude(s => s.RegisterMember)
                .ToList();

           return eventdetails.Select(e => new EventResponseViewModel
            {
                EventId = e.EventId,
                Title = e.Title,
                EventName = e.EventName,
                VenueName = e.VenueName,
                Address = e.Address,
                City = e.City,
                Country = e.Country,
               State = e.State,
               PostalCode = e.PostalCode,
                Phone = e.Phone,
                Website = e.Website,
                OrganizerName = e.OrganizerName,
                OrganizerPhone = e.OrganizerPhone,
                OrganizerWebsite = e.OrganizerWebsite,
                OrganizerEmail = e.OrganizerEmail,
                EventWebsite = e.EventWebsite,
                EventCost = e.EventCost,
                EventStatus = e.EventStatus,
               // EventStatusTrack = CommanHelper.GetEventStatus((int)e.EventStatus),
                EventDate = e.EventDate,
                StartTime = e.StartTime,
                EventEndDate = e.EventEndDate,
                EndTime = e.EndTime,
                Description = e.Description,
                CreatedOn = e.CreatedOn,
                CreatedBy = e.CreatedBy,
                IsBookmark = e.TblEventBookmark.Count > 0 ? true : false,
                lstEventAttachment = e.TblEventAttachment.Count > 0 ? e.TblEventAttachment.Select(r => new EventAttachment
                {
                    EventAttachmentId = r.EventAttachmentId,
                    EventId = r.EventId,
                    FileName = Constant.livebaseurl + "Events/" + r.FileName,
                }).ToList() : null,
               lstEventJoinMembers = e.TblEventRegisterMember.Count > 0 ? e.TblEventRegisterMember.Select(t => new EventJoinMemberViewModel
               {
                   MemberProfile = t.RegisterMember != null ? Constant.livebaseurl + "Profiles/" + t.RegisterMember.ProfileImage : null,
                   MemberName = t.RegisterMember != null ? t.RegisterMember.FirstName + " " + t.RegisterMember.LastName : null
               }).ToList() : null,
               Attendee = e.TblEventRegisterMember.Count,
                // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).ToList();

           
        }
        public EventResponseViewModel GetEventListById(int eventid)
        {
            var eventdetails = _entityDbContext.TblEvent.Where(r => r.EventId== eventid).Select(e => new EventResponseViewModel
            {
                EventId = e.EventId,
                Title = e.Title,
                EventName = e.EventName,
                VenueName = e.VenueName,
                Address = e.Address,
                City = e.City,
                Country = e.Country,
                State = e.State,
                PostalCode = e.PostalCode,
                Phone = e.Phone,
                Website = e.Website,
                OrganizerName = e.OrganizerName,
                OrganizerPhone = e.OrganizerPhone,
                OrganizerWebsite = e.OrganizerWebsite,
                OrganizerEmail = e.OrganizerEmail,
                EventWebsite = e.EventWebsite,
                EventCost = e.EventCost,
                EventStatus = e.EventStatus,
                EventStatusTrack = CommanHelper.GetEventStatus((int)e.EventStatus),
                EventDate = e.EventDate,
                StartTime = e.StartTime,
                EventEndDate = e.EventEndDate,
                EndTime = e.EndTime,
                Description = e.Description,
                CreatedOn = e.CreatedOn,
                CreatedBy = e.CreatedBy,
                lstEventAttachment = e.TblEventAttachment.Count > 0 ? e.TblEventAttachment.Select(r => new EventAttachment
                {
                    EventAttachmentId = r.EventAttachmentId,
                    EventId = r.EventId,
                    FileName = Constant.livebaseurl + "Events/" + r.FileName,
                }).ToList() : null,
                Attendee = e.TblEventRegisterMember.Count,
                // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).FirstOrDefault();

            return eventdetails;
        }

        public List<EventResponseViewModel> GetEventListByFilter(EventFilterViewModel model)
        {
            var eventdetails = new List<TblEvent>();
           

                if (model.Type == 0)
                {
                    eventdetails = _entityDbContext.TblEvent.Where(e => e.IsDeleted != true)
                         .Include(s => s.TblEventAttachment)
                          .Include(s => s.TblEventBookmark)
                          .Include(s => s.TblEventRegisterMember)
                           .ThenInclude(s => s.RegisterMember)
                        .ToList();
                }
                if (model.Type == 1)
                {
                    eventdetails = _entityDbContext.TblEvent.Where(e => e.IsDeleted != true && e.EventDate >= DateTime.Now)
                         .Include(s => s.TblEventAttachment)
                          .Include(s => s.TblEventBookmark)
                          .Include(s => s.TblEventRegisterMember)
                           .ThenInclude(s => s.RegisterMember)
                        .ToList();
                }
                if (model.Type == 2 || model.Type == 3)
                {
                    eventdetails = _entityDbContext.TblEvent.Where(e => e.IsDeleted != true && e.EventType == model.Type)
                         .Include(s => s.TblEventAttachment)
                          .Include(s => s.TblEventBookmark)
                          .Include(s => s.TblEventRegisterMember)
                           .ThenInclude(s => s.RegisterMember)
                        .ToList();
                }
                if (model.Type == 4)
                {

                    var bookmarksdetails = _entityDbContext.TblEventBookmark.Where(e => e.MemberId == model.MemberiD).Select(k => k.EventId).ToList();

                    eventdetails = _entityDbContext.TblEvent.Where(e => e.IsDeleted != true && bookmarksdetails.Contains(e.EventId))
                        .Include(s => s.TblEventAttachment)
                         .Include(s => s.TblEventBookmark)
                          .Include(s => s.TblEventRegisterMember)
                           .ThenInclude(s => s.RegisterMember)
                       .ToList();
                   
               
            }

            return eventdetails.Select(e => new EventResponseViewModel
            {
                EventId = e.EventId,
                Title = e.Title,
                EventName = e.EventName,
                VenueName = e.VenueName,
                Address = e.Address,
                City = e.City,
                Country = e.Country,
                State = e.State,
                PostalCode = e.PostalCode,
                Phone = e.Phone,
                Website = e.Website,
                OrganizerName = e.OrganizerName,
                OrganizerPhone = e.OrganizerPhone,
                OrganizerWebsite = e.OrganizerWebsite,
                OrganizerEmail = e.OrganizerEmail,
                EventWebsite = e.EventWebsite,
                EventCost = e.EventCost,
                EventStatus = e.EventStatus,
               // EventStatusTrack = CommanHelper.GetEventStatus((int)e.EventStatus),
                EventDate = e.EventDate,
                StartTime = e.StartTime,
                EventEndDate = e.EventEndDate,
                EndTime = e.EndTime,
                Description = e.Description,
                CreatedOn = e.CreatedOn,
                CreatedBy = e.CreatedBy,
                IsBookmark = e.TblEventBookmark.Count > 0 ? true : false,
                lstEventAttachment = e.TblEventAttachment.Count > 0 ? e.TblEventAttachment.Select(r => new EventAttachment
                {
                    EventAttachmentId = r.EventAttachmentId,
                    EventId = r.EventId,
                    FileName = Constant.livebaseurl + "Events/" + r.FileName,
                }).ToList() : null,
                lstEventJoinMembers = e.TblEventRegisterMember.Count > 0 ? e.TblEventRegisterMember.Select(t => new EventJoinMemberViewModel
                {
                    MemberProfile = t.RegisterMember != null ? Constant.livebaseurl + "Profiles/" + t.RegisterMember.ProfileImage : null,
                    MemberName = t.RegisterMember != null ? t.RegisterMember.FirstName + " " + t.RegisterMember.LastName : null
                }).ToList() : null,
                Attendee = e.TblEventRegisterMember.Count,
                // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).ToList();

           
        }
        public string EventBookmark(EventBookmarkViewModel model)
        {
            TblEventBookmark bookmark = new TblEventBookmark();

            if (model.BookmarkId > 0)
            {
                var result = _entityDbContext.TblEventBookmark.Where(e => e.BookmarkId == model.BookmarkId).FirstOrDefault();

                if (result != null)
                {
                    _entityDbContext.TblEventBookmark.Remove(result);
                    _entityDbContext.SaveChanges();
                    return "Unbookmark";
                }
            }
            else
            {
                bookmark.MemberId = model.MemberId;
                bookmark.EventId = model.EventId;
               
                _entityDbContext.TblEventBookmark.Add(bookmark);
                _entityDbContext.SaveChanges();
                return "bookmark";
            }
            return "bookmark";
        }
        public long ManageEvent(EventViewModel model)
        {
            TblEvent evnt = new TblEvent();
            if(model.EventId>0)
            evnt = GetEventById((int)model.EventId);

            evnt.Title = model.Title;
            evnt.EventName = model.EventName;
            evnt.VenueName = model.VenueName;
            evnt.Address = model.Address;
            evnt.City = model.City;
            evnt.Country = model.Country;
            evnt.State = model.State;
            evnt.PostalCode = model.PostalCode;
            evnt.Phone = model.Phone;
            evnt.Website = model.Website;
            evnt.OrganizerName = model.OrganizerName;
            evnt.OrganizerPhone = model.OrganizerPhone;
            evnt.OrganizerWebsite = model.OrganizerWebsite;
            evnt.OrganizerEmail = model.OrganizerEmail;
            evnt.EventWebsite = model.EventWebsite;
            evnt.EventCost = model.EventCost;
            evnt.EventStatus = model.EventStatus;
            evnt.EventDate = model.EventDate;
            evnt.StartTime = model.StartTime;
            evnt.EventEndDate = model.EventEndDate;
            evnt.EndTime = model.EndTime;
            evnt.Description = model.Description;
            evnt.CreatedOn = DateTime.Now;
            evnt.CreatedBy = model.CreatedBy;
            evnt.EventType = model.EventType;
            evnt.EventLink = model.EventLink;
            if (model.EventId == 0)
                _entityDbContext.TblEvent.Add(evnt);

            _entityDbContext.SaveChanges();
            return evnt.EventId;
        }

        public string UploadEventAttachment(List<TblEventAttachment> attchment)
        {

            _entityDbContext.TblEventAttachment.AddRange(attchment);
            _entityDbContext.SaveChanges();
            return Constant.Success;
        }

        public RegisterMemberEventViewModel RegisterEventMember(RegisterMemberEventViewModel model)
        {
            TblEventRegisterMember evntmember = new TblEventRegisterMember();
            evntmember.EventId = model.EventId;
            evntmember.RegisterMemberId = model.RegisterMemberId;
            evntmember.Status = 0;
            _entityDbContext.TblEventRegisterMember.Add(evntmember);

            _entityDbContext.SaveChanges();

            _entityDbContext.SaveChanges();

            //member earn point
            RedeemPointsViewModel reddem = new RedeemPointsViewModel();
            reddem.MemberId = model.RegisterMemberId;
            reddem.Description = "Earn Point By Join A Event";
            reddem.ReddemPoint = 25;

            return model;
        }

        public string UpdateEventStatus(RegisterMemberEventViewModel model)
        {

            var checkevent = GetEventById((int)model.EventId);
            if (checkevent != null)
            {
                checkevent.EventStatus = model.Status;
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }



        public string DeleteEvent(int eventid)
        {

            var checkevent = GetEventById((int)eventid);
            if (checkevent != null)
            {
                checkevent.IsDeleted = true;
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }

        public string DeleteEventAttachment(int eventid)
        {

            var checkevent = _entityDbContext.TblEventAttachment.Where(r => r.EventAttachmentId == eventid).FirstOrDefault();
            if (checkevent != null)
            {
                _entityDbContext.TblEventAttachment.Remove(checkevent);
                _entityDbContext.SaveChanges();
            }
            return Constant.Success;
        }

        public TblEvent GetEventById(int eventid)
        {
            return _entityDbContext.TblEvent.Where(e => e.EventId == eventid).FirstOrDefault();
        }


    }
}
