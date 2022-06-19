using AutoMapper;
using Leave.Data;
using Leave.Models;


namespace Leave.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Leave_type, Leave_type_view_model>().ReverseMap();
            CreateMap<Leave_history, leave_history_view_model>().ReverseMap();
            CreateMap<Leave_allocation, Leave_allocation_view_model>().ReverseMap();
            CreateMap<Employee, Employee_view_model>().ReverseMap();

        }
    }
}
