using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Information.DTOs;
using Contact_Information.Interfaces.Users;
using Contact_Information.IRepository;
using Contact_Information.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Contact_Information.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public SaveUserDTO SaveUserDTO { get; set; }

        [BindProperty]
        public UpdateUserDTO UpdateUserDTO { get; set; }

        public IList<UserDTO> UsersDTO { get; set; }

        public SelectList locationList { get; set; }


        public IndexModel(IUnitOfWork unitOfWork, IMapper mapper,   ILogger<IndexModel> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var UserList = await _unitOfWork.Users.GetAll(includes: new List<string>() { "Location" });
            var results = _mapper.Map<IList<UserDTO>>(UserList);
            UsersDTO = results;
            var LocationList = await _unitOfWork.Locations.GetAll();
            TempData["locationList"] = JsonConvert.SerializeObject(LocationList);
            locationList = new SelectList(LocationList, "LocationId", "LocationName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userDetails = _mapper.Map<User>(SaveUserDTO);
            await _unitOfWork.Users.Insert(userDetails);
            await _unitOfWork.Save();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostUpdateUser(UpdateUserDTO updateUserDTO)
        {
            var userDetail = _mapper.Map<User>(UpdateUserDTO);
            _unitOfWork.Users.Update(userDetail);
            await _unitOfWork.Save();
            return RedirectToPage("./Index");
        }

        //public async Task<JsonResult> OnPostUpdateUser(UpdateUserDTO updateUserDTO)
        //{
        //    User user = new User();
        //    user.UserId = updateUserDTO.UserId;
        //    user.UserName = updateUserDTO.UserName;
        //    user.LocationId = updateUserDTO.LocationId;
        //    if (user != null)
        //    {
        //        _unitOfWork.Users.Update(user);
        //        _unitOfWork.Save();
        //        return new JsonResult(user);
        //    }
        //    var error = "error";
        //    Response.StatusCode = (int)HttpStatusCode.Conflict;
        //    return new JsonResult(error);
        //}

        public JsonResult OnGetOneUser(int userId)
        {
            var user = _unitOfWork.Users.Get(x => x.UserId == userId, includes: new List<string>() { "Location"} ).GetAwaiter().GetResult();
            return new JsonResult(user);

        }

        public JsonResult OnGetUserDetails()
        {
            var UserResult = _unitOfWork.Users.GetAll(includes: new List<string>() { "Location"}).GetAwaiter().GetResult();
            if(UserResult != null) 
            {
                return new JsonResult(UserResult);
            }
            var error = "error";
            return new JsonResult(error);
        }
    }

}
