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
            var eventdetails = _entityDbContext.TblEvent.OrderByDescending(r=>r.EventId).Select(e => new EventResponseViewModel
            {
                EventId=e.EventId,
                Title = e.Title,
                EventName = e.EventName,
                VenueName = e.VenueName,
                Address = e.Address,
                City = e.City,
                Country = e.Country,
                State = 0,
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
               StartTime=e.StartTime,
                EventEndDate = e.EventEndDate,
                EndTime=e.EndTime,
                Description = e.Description,
                CreatedOn = e.CreatedOn,
                CreatedBy = e.CreatedBy,
                lstEventAttachment = e.TblEventAttachment.Count > 0 ? e.TblEventAttachment.Select(r => new EventAttachment
                {
                    EventAttachmentId = r.EventAttachmentId,
                    EventId = r.EventId,
                    FileName = Constant.livebaseurl + "Events/" + r.FileName,
                }).ToList() : null,
                Attendee =e.TblEventRegisterMember.Count,
               // CreatedByMember=e.TblEventRegisterMember!=null?e.t

            }).ToList();

            return eventdetails;
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
            evnt.State = 0;
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

        public TblEvent GetEventById(int eventid)
        {
            return _entityDbContext.TblEvent.Where(e => e.EventId == eventid).FirstOrDefault();
        }


    }
}
