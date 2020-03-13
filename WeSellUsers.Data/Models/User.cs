using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WeSellUsers.Data.Models
{
  public class User
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [MaxLength(255)]
    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    [MaxLength(255)]
    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [MaxLength(255)]
    [DataType(DataType.EmailAddress)]
    [JsonProperty("email")]
    public string Email { get; set; }
  }
}
