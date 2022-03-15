

function sortUSTable(n) {
  var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
  table = document.getElementById("UpcomingServiceTable");
  switching = true;
  dir = "asc";
  while (switching) {
    switching = false;
    rows = table.rows;
    for (i = 1; i < (rows.length - 1); i++) {
      shouldSwitch = false;
      x = rows[i].getElementsByTagName("TD")[n];
      y = rows[i + 1].getElementsByTagName("TD")[n];
      if (dir == "asc") {
        if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
          shouldSwitch = true;
          break;
        }
      } else if (dir == "desc") {
        if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
          shouldSwitch = true;
          break;
        }
      }
    }
    if (shouldSwitch) {
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
      switching = true;
      switchcount++;
    } else {
      if (switchcount == 0 && dir == "asc") {
        dir = "desc";
        switching = true;
      }
    }
  }
}



function sortNSTable(n) {
  var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
  table = document.getElementById("NewServTable");
  switching = true;
  dir = "asc";
  while (switching) {
    switching = false;
    rows = table.rows;
    for (i = 1; i < (rows.length - 1); i++) {
      shouldSwitch = false;
      x = rows[i].getElementsByTagName("TD")[n];
      y = rows[i + 1].getElementsByTagName("TD")[n];
      if (dir == "asc") {
        if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
          shouldSwitch = true;
          break;
        }
      } else if (dir == "desc") {
        if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
          shouldSwitch = true;
          break;
        }
      }
    }
    if (shouldSwitch) {
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
      switching = true;
      switchcount++;
    } else {
      if (switchcount == 0 && dir == "asc") {
        dir = "desc";
        switching = true;
      }
    }
  }
}



function sortSHTable(n) {
  var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
  table = document.getElementById("ServHistoryTable");
  switching = true;
  dir = "asc";
  while (switching) {
    switching = false;
    rows = table.rows;
    for (i = 1; i < (rows.length - 1); i++) {
      shouldSwitch = false;
      x = rows[i].getElementsByTagName("TD")[n];
      y = rows[i + 1].getElementsByTagName("TD")[n];
      if (dir == "asc") {
        if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
          shouldSwitch = true;
          break;
        }
      } else if (dir == "desc") {
        if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
          shouldSwitch = true;
          break;
        }
      }
    }
    if (shouldSwitch) {
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
      switching = true;
      switchcount++;
    } else {
      if (switchcount == 0 && dir == "asc") {
        dir = "desc";
        switching = true;
      }
    }
  }
}






function TabNSClick() {
  $("#NewServReqTab").addClass("active");
  $("#UpcomingServTab").removeClass("active");
  $("#ServHistoryTab").removeClass("active");
  $("#BlockCustTab").removeClass("active");

  $(".NewServContainer").show();
  $(".ServHistory").hide();
  $(".UpcomingServiceContainer").hide();
  $(".BlockCust").hide();
    $(".provider-setting").hide();
  
}

function TabUSClick() {
  
  $("#NewServReqTab").removeClass("active");
  $("#UpcomingServTab").addClass("active");
  $("#ServHistoryTab").removeClass("active");
  $("#BlockCustTab").removeClass("active");

  $(".NewServContainer").hide();
  $(".ServHistory").hide();
  $(".UpcomingServiceContainer").show();
  $(".BlockCust").hide();
    $(".provider-setting").hide();
}

function TabSHClick() {
  
  $("#NewServReqTab").removeClass("active");
  $("#UpcomingServTab").removeClass("active");
  $("#ServHistoryTab").addClass("active");
  $("#BlockCustTab").removeClass("active");

  $(".NewServContainer").hide();
  $(".ServHistory").show();
  $(".UpcomingServiceContainer").hide();
  $(".BlockCust").hide();
    $(".provider-setting").hide();
}


function TabBCClick() {
  
  $("#NewServReqTab").removeClass("active");
  $("#UpcomingServTab").removeClass("active");
  $("#ServHistoryTab").removeClass("active");
  $("#BlockCustTab").addClass("active");

  $(".NewServContainer").hide();
  $(".ServHistory").hide();
  $(".UpcomingServiceContainer").hide();
  $(".BlockCust").show();
    $(".provider-setting").hide();
}




function TabNSNav() {

  $(".NewServContainer").show();
  $(".ServHistory").hide();
  $(".UpcomingServiceContainer").hide();
  $(".BlockCust").hide();
    $(".provider-setting").hide();
}

function TabUSNav() {

  $(".NewServContainer").hide();
  $(".ServHistory").hide();
  $(".UpcomingServiceContainer").show();
    $(".BlockCust").hide();
    $(".provider-setting").hide();

}

function TabSHNav() {

  $(".NewServContainer").hide();
  $(".ServHistory").show();
  $(".UpcomingServiceContainer").hide();
  $(".BlockCust").hide();
    $(".provider-setting").hide();

}

function TabBCNav() {

  $(".NewServContainer").hide();
  $(".ServHistory").hide();
  $(".UpcomingServiceContainer").hide();
  $(".BlockCust").show();
  $(".provider-setting").hide();
}







function MySetting() {

    $("#NewServReqTab").removeClass("active");
    $("#UpcomingServTab").removeClass("active");
    $("#ServHistoryTab").removeClass("active");
    $("#BlockCustTab").removeClass("active");

    $("#MyDetails").addClass("active2")
    $("#change-pass").removeClass("active2")

    $(".NewServContainer").hide();
    $(".ServHistory").hide();
    $(".UpcomingServiceContainer").hide();
    $(".BlockCust").hide();
    $(".provider-setting").show();
    $("#tab1").show();
    $("#tab2").hide();
}



function settingTab1() {
    $("#NewServReqTab").removeClass("active");
    $("#UpcomingServTab").removeClass("active");
    $("#ServHistoryTab").removeClass("active");
    $("#BlockCustTab").removeClass("active");




    $("#MyDetails").addClass("active2")
    $("#change-pass").removeClass("active2")

    $(".NewServContainer").hide();
    $(".ServHistory").hide();
    $(".UpcomingServiceContainer").hide();
    $(".BlockCust").hide();
    $(".provider-setting").show();
    $("#tab1").show();
    $("#tab2").hide();
}
function settingTab2() {
    $("#NewServReqTab").removeClass("active");
    $("#UpcomingServTab").removeClass("active");
    $("#ServHistoryTab").removeClass("active");
    $("#BlockCustTab").removeClass("active");

    $("#MyDetails").removeClass("active2")
    $("#change-pass").addClass("active2")

    $(".NewServContainer").hide();
    $(".ServHistory").hide();
    $(".UpcomingServiceContainer").hide();
    $(".BlockCust").hide();
    $(".provider-setting").show();
    $("#tab2").show();
    $("#tab1").hide();
}










$(document).ready(function () {

    getServiceHistoryTable();

});

function getServiceHistoryTable() {
    $.ajax({
        type: "GET",
        url: '/UserPage/getServiceHistory',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        success: function (result) {
            $('#ServiceHistoryTbody').empty();

            for (var i = 0; i < result.length; i++) {

                $('#ServiceHistoryTbody').append(' <tr data-value=' + result[i].serviceRequestId + ' > <td data-label="Service ID" class="SH-ServId">'
                    + '<span>' + result[i].serviceRequestId + '</span></td>'
                    + '<td data-label="Service Date"> <div class="SH-ServDateSpan"><p><img src="/Images/calendar2.png" alt="calender">&nbsp;' + '<span class="service-date">'
                    + result[i].date + ' </span></p >'
                    + '<p><img src="/Images/layer-14.png" alt="clock">&nbsp;' + result[i].startTime + '-' + result[i].endTime + '</p></div></td>'
                    + '<td class="SH-CustDetail" data-lable="Customer Details"><p>' + result[i].customerName + '</p>'
                    + '<p><img src="/Images/layer-15.png" alt="Home" style="padding-bottom: 3px;">&nbsp;<span class="detailContent2">' + result[i].address + ' </span>'
                    + '</p></td></tr>');

            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}







$(document).ready(function () {
    getsettingsdata();
});

function getsettingsdata() {

    $.ajax({
        type: 'GET',
        url: '/UserPage/GetProData',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',

        success: function (result) {

            var firstname = document.getElementById("detail-fname");
            var lastname = document.getElementById("detail-lname");
            var email = document.getElementById("detail-email");
            var phoneno = document.getElementById("detail-mobile");
            var Street = document.getElementById("detail-streetname");
            var houseno = document.getElementById("detail-Houseno");
            var pincode = document.getElementById("detail-zipcode");
            var city = document.getElementById("detail-city");

            firstname.value = result.user.firstName;
            lastname.value = result.user.lastName;
            email.value = result.user.email;
            phoneno.value = result.user.mobile;

            if (result.address != null) {
                Street.value = result.address.addressLine2;
                pincode.value = result.address.postalCode;
                city.value = result.address.city;
                houseno.value = result.address.addressLine1;

                getCityFromPostalCode(result.address.postalCode);
            }


            if (result.user.dateOfBirth != null) {

                var dateOfBirth = result.user.dateOfBirth.split('T');
                var dateOfBirthArray = dateOfBirth[0].split("-");
                console.log(dateOfBirthArray);
                $("#dobday").val(dateOfBirthArray[2]);
                $("#dobmonth").val(dateOfBirthArray[1]);
                $("#dobyear").val(dateOfBirthArray[0]);
            }

            if (result.user.nationalityId != null) {

                $("#Nationality").val(result.user.nationalityId);

            }

          if (result.user.gender != null) {

                $("input[name=Gender][value='" + result.user.gender + "']").prop("checked", true);
            }
        /*
           if (result.user.userProfilePicture != null) {
                $("input[name=avtar][value='" + result.user.userProfilePicture + "']").prop("checked", true);
            } */


        },
        error: function () {
            alert("error");
        }
    });
}










$("#DetailsSubmit").on('click', function () {


    var data = {};
    data.user = {};
    data.address = {};

    data.user.firstName = document.getElementById("detail-fname").value;
    data.user.lastName = document.getElementById("detail-lname").value;
    data.user.email = document.getElementById("detail-email").value;
    data.user.mobile = document.getElementById("detail-mobile").value;
    data.user.dateOfBirth = $("#dobday").val() + "/" + $("#dobmonth").val() + "/" + $("#dobyear").val();

    data.user.nationalityId = $("#Nationality").val();
    data.user.gender = document.querySelector('input[name="Gender"]:checked').value;
    //data.user.userProfilePicture = document.querySelector('input[name="avtar"]:checked').value;
    data.address.addressLine2 = document.getElementById("detail-streetname").value;
    data.address.addressLine1 = document.getElementById("detail-Houseno").value;
    data.address.postalCode = document.getElementById("detail-zipcode").value;
    data.address.city = document.getElementById("detail-city").value;
    //data.address.state = document.getElementById("SPSettingsState").value;
    data.address.email = document.getElementById("detail-email").value;
    data.address.mobile = document.getElementById("detail-mobile").value;


    


    
        $.ajax({
            type: 'POST',
            url: '/UserPage/UpdateProData',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success: function (result) {
                if (result.value == "true") {



                    alert("Data Updated");
                    

                }
                else {
                    alert("Please Try Again");
                }
            },
            error: function () {
                alert("error");
            }
        });

    

});













$("#ChangePassword").on('click', function () {

    var data = {};
    data.oldPassword = document.getElementById("old-password").value;
    data.newPassword = document.getElementById("new-password").value;
    data.confirmPassword = document.getElementById("cnfrm-password").value;


    $.ajax({
            type: "POST",
            url: "/UserPage/ProChangePassword",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: data,
            success: function (result) {
                if (result.value == "true") {
                    alert("Password Changed Successfully.");
                }
                else if (result.value == "false") {
                    alert("Current(Old) Password is wrong! Please try again.");
                }
            },
            error: function (error) {
                alert("Something went wrong! Please try again leter.");
            }
    });
    

});


