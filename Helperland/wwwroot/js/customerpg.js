function Tab1Click() {
    $("#dashboardBtn").addClass("active");
    $("#historyBtn").removeClass("active");

    $(".dashboard-table").show();
    $(".main-table").hide();
    $(".my-setting").hide();
    
}

function Tab2Click() {
    
    $("#dashboardBtn").removeClass("active");
    $("#historyBtn").addClass("active");

    $(".dashboard-table").hide();
    $(".main-table").show();
    $(".my-setting").hide();

}

function Tab1Nav() {

    $(".dashboard-table").show();
    $(".main-table").hide();
    $(".my-setting").hide();
}

function Tab2Nav() {

    $(".dashboard-table").hide();
    $(".main-table").show();
    $(".my-setting").hide();

}


/*var checkTextarea = (e) => {
    const content = $("#canText").val().trim();
    $('#cancelServBtn').prop('disabled', content === '');
  };
  
  $(document).on('keyup', '#canText', checkTextarea);*/




function MySetting() {
    
    $("#dashboardBtn").removeClass("active");
    $("#historyBtn").removeClass("active");
    $("#MyDetails").addClass("active2")
    $("#MyAddress").removeClass("active2")
    $("#change-pass").removeClass("active2")

    $(".dashboard-table").hide();
    $(".main-table").hide();
    $(".my-setting").show();
    $("#tab1").show();
    $("#tab2").hide();
    $("#tab3").hide();
}

function settingTab1(){
    $("#dashboardBtn").removeClass("active");
    $("#historyBtn").removeClass("active");
    $("#MyDetails").addClass("active2")
    $("#MyAddress").removeClass("active2")
    $("#change-pass").removeClass("active2")

    $(".dashboard-table").hide();
    $(".main-table").hide();
    $(".my-setting").show();
    $("#tab1").show();
    $("#tab2").hide();
    $("#tab3").hide();
}
function settingTab2(){
    $("#dashboardBtn").removeClass("active");
    $("#historyBtn").removeClass("active");
    $("#MyAddress").addClass("active2")
    $("#MyDetails").removeClass("active2")
    $("#change-pass").removeClass("active2")

    $(".dashboard-table").hide();
    $(".main-table").hide();
    $(".my-setting").show();
    $("#tab2").show();
    $("#tab1").hide();
    $("#tab3").hide();
}
function settingTab3(){
    $("#dashboardBtn").removeClass("active");
    $("#historyBtn").removeClass("active");
    $("#MyAddress").removeClass("active2")
    $("#MyDetails").removeClass("active2")
    $("#change-pass").addClass("active2")

    $(".dashboard-table").hide();
    $(".main-table").hide();
    $(".my-setting").show();
    $("#tab3").show();
    $("#tab1").hide();
    $("#tab2").hide();
}



var serviceRequestId = "";
$(".dashbordTable").click(function (e) {


    serviceRequestId = e.target.closest("tr").getAttribute("data-value");

    if (e.target.id == "customerReschedule") {
        document.getElementById("updateRequestId").value = e.target.value;

    }
    if (e.target.classList == "customerCancel") {
        document.getElementById("CancelRequestId").value = e.target.value;
    }

    if (serviceRequestId != null && (e.target.classList != "customerCancel" && e.target.classList != "customerReschedule")) {


        document.getElementById("serviceReqdetailsbtn").click();
        srId = serviceRequestId;
    }
    console.log(e);
});


document.getElementById("RescheduleUpdateBtn").addEventListener("click", function () {
    //var serviceStartDate = document.getElementById("RescheduledDate").value;
    //var serviceTime = document.getElementById("RescheduledTime").value;
    //var serviceRequestId = document.getElementById("updateRequestId").value;
    //console.log(serviceRequestId);
    var data = {};
    data.Date = document.getElementById("RescheduledDate").value;
    data.startTime = document.getElementById("RescheduledTime").value;
    data.serviceRequestId = document.getElementById("updateRequestId").value;

    $.ajax({
        type: 'POST',
        url: '/UserPage/RescheduleService',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {

                alert("Service Rescheduled");
                window.location.reload();
            }
            else {
                alert("fail");
            }
        },
        error: function () {
            alert("error");
        }
    });
});





document.getElementById("cancelServBtn").addEventListener("click", function () {

    var ServiceRequestId = document.getElementById("CancelRequestId").value;
    var Comments = document.getElementById("canText").value;
    var data = {};

    data.serviceRequestId = ServiceRequestId;
    data.comments = Comments;

    $.ajax({
        type: 'POST',
        url: '/UserPage/CancelService',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
                alert("Booking Cancelled");
                window.location.reload();
            }
            else {
                alert("fail");
            }
        },
        error: function () {
            alert("error");
        }
    });

});






/*  for cancel status 1-created, 2-assigned, 3-complted 4-cancled  */






function getAllServiceDetails() {
    var data = {};
    data.ServiceRequestId = parseInt(serviceRequestId);
    $.ajax({
        type: 'GET',
        url: '/UserPage/DashbordServiceDetails',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result != null) {

                showAllServiceRequestDetails(result);

            }
            else {
                alert("result is null");
            }

        },
        error: function () {

            alert("error");
        }
    });
}

function showAllServiceRequestDetails(result) {
    var dateTime = document.getElementById("serviceDetailDateTime");
    var duration = document.getElementById("serviceDetailDuration");
    document.getElementById("serviceDetailId").innerHTML = serviceRequestId;
    var extra = document.getElementById("serviceDetailExtra");
    var amount = document.getElementById("serviceDetailAmount");
    var address = document.getElementById("serviceDetailAddress");
    var phone = document.getElementById("serviceDetailPhone");
    var email = document.getElementById("serviceDetailEmail");
    var comment = document.getElementById("serviceDetailComment");
    var Status = document.getElementById("serviceDetailStatus");
    dateTime.innerHTML = result.date.substring(0, 10) + " " + result.startTime + " - " + result.endTime;
    duration.innerHTML = result.duration + " Hrs";
    extra.innerHTML = "";
    var varStatus = "";
    var dashbtn = "";
    var servicehistorybtn = "";
    switch (result.status) {
        case 1: /*new */
            varStatus = "new";
            dashbtn = "";
            servicehistorybtn = "d-none";

            break;
        case 2: /*pending */
            varStatus = "pending";
            dashbtn = "";
            servicehistorybtn = "d-none";
            break;
        case 3: /*completed */
            varStatus = "completed";
            dashbtn = "d-none";
            servicehistorybtn = "";
            break;
        case 4: /*cancelled*/
            varStatus = "cancelled";
            dashbtn = "d-none";
            servicehistorybtn = "d-none";
            break;
        default: /*other status */
            alert("invalid status ")

    }

    document.getElementById("customerdashboardbtn").className = dashbtn;

    document.getElementById("customerServiceHistorybtn").className = servicehistorybtn;

    Status.innerHTML = " Status: <button disabled class=" + varStatus + ">" + varStatus + "</button > "


    if (result.cabinet == true) {
        extra.innerHTML += "<div class='extraElement '> Inside Cabinet </div> ";
    }
    if (result.laundry == true) {

        extra.innerHTML += "<div class='extraElement'>  Laundry Wash & dry </div> ";
    }
    if (result.oven == true) {
        extra.innerHTML += "<div class='extraElement'>  Inside Oven  </div> ";
    }
    if (result.fridge == true) {
        extra.innerHTML += " <div class='extraElement'> Inside </div>  ";
    }
    if (result.window == true) {
        extra.innerHTML += "<div class='extraElement'>  Interior Window</div> ";
    }
    amount.innerHTML = result.totalCost + " &euro;";
    address.innerHTML = result.address;
    phone.innerHTML = result.phoneNo;
    email.innerHTML = result.email;
    comment.innerHTML = "";
    if (result.comments != null) {
        comment.innerHTML = result.comments;
    }
}


document.getElementById("serviceReqdetailsbtn").addEventListener("click", function () {

    getAllServiceDetails();

});











var currentYear = new Date().getFullYear()
var option = "";
for (var year = 1940; year <= currentYear; year++) {

    var option = document.createElement("option");
    option.text = year;
    option.value = year;

    document.getElementById("dobyear").appendChild(option)

}
document.getElementById("dobyear").value = currentYear;





$(document).ready(function () {


    $.ajax({
        type: 'GET',
        url: '/UserPage/GetCustomerData',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',

        success: function (result) {



            var form1_firstname = document.getElementById("detail-fname");
            var form1_lastname = document.getElementById("detail-lname");
            var form1_email = document.getElementById("detail-email");
            var form1_phoneno = document.getElementById("detail-mobile");

            form1_firstname.value = result.firstName;
            form1_lastname.value = result.lastName;
            form1_email.value = result.email;
            form1_phoneno.value = result.mobile;


            console.log(result.dateOfBirth);

            if (result.dateOfBirth != null) {
                var dateOfBirth = result.dateOfBirth.split('T');
                var dateOfBirthArray = dateOfBirth[0].split("-");
                console.log(dateOfBirthArray);
                $("#dobday").val(dateOfBirthArray[2]);
                $("#dobmonth").val(dateOfBirthArray[1]);
                $("#dobyear").val(dateOfBirthArray[0]);
            }


        },
        error: function () {
            alert("error");
        }
    });
});






$("#SaveDetails").on('click', function () {



    var data = {};
    data.firstName = document.getElementById("detail-fname").value;
    data.lastName = document.getElementById("detail-lname").value;
    data.email = document.getElementById("detail-email").value;
    data.mobile = document.getElementById("detail-mobile").value;
    data.dateOfBirth = $("#dobday").val() + "-" + $("#dobmonth").val() + "-" + $("#dobyear").val();

    console.log(data.dateOfBirth);
    
    
    $.ajax({
            type: 'POST',
            url: '/UserPage/UpdateCustomer',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
        success: function (result) {

            if (result.value == "true") {
                window.location.reload();
                alert("User Details Updated");
                 
            }
            else {

                alert("Update Unsuccessful Please Try Again!!")
            }
        },
        error: function () {
                alert("error");
        }
    });
    

});











$(document).ready(function () {

    getAddress();

});

function getAddress() {
    $.ajax({
        type: 'GET',
        url: '/UserPage/GetUserAddress',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',

        success: function (result) {
            if (result != false) {

                console.log(result);

                for (var i = 0; i < result.length; i++) {

                    $("#addressRows").append(

                        '<tr data-value=' + result[i].addressId + ' >'
                        + '<td class="address-details" data-label="Addresses"><div class="addressdetaildiv text-start"><p><strong> Address: </strong>' + result[i].addressLine1 + ", " + result[i].addressLine2 + ', ' + result[i].city + ' - ' + result[i].postalCode + '</p>'
                        + '<p><strong>Phone number: </strong>' + result[i].mobile + '</p></div></td>'
                        + '<td class="myAddressBtns" data-label="Action"><div class="address-action"><p>' +
                        '<button id = "editAddress" class= "btn-primary rounded-pill editAddress" style = "margin-right:5px;padding: 5px 15px; border: none;" data-value=' + result[i].addressId + '>Edit</button >' +
                        '<button id="deleteAddress" class="btn-danger rounded-pill deleteAddress" style="padding: 5px 15px; border: none;" data-value=' + result[i].addressId + '>Delete</button >' +
                        '</p></div></td >'

                       
                    );

                   /* $("#addressRows").attr('data-value', result[i].addressId);

                    $("#addressTr").append(
                        "<span>" + result[i].addressLine1 + ", " + result[i].addressLine2 + ', ' + result[i].city + ' - ' + result[i].postalCode + "</span>"
                    );

                    $("#phoneTr").append(
                        "<span>" + result[i].mobile + "</span>"
                    );

                    $("#editAddress").attr('data-value', result[i].addressId);
                    $("#deleteAddress").attr('data-value', result[i].addressId);*/

                }


            }
            else {
                alert("something wrong");
            }
        },
        error: function () {
            alert("error");
        }
    });
}




$("#addAddresssave").on('click', function () {



    var data = {};
    data.addressLine1 = document.getElementById("addAddressLine1").value;
    data.addressLine2 = document.getElementById("addAddressLine2").value;
    data.postalCode = document.getElementById("addAddressPostalCode").value;
    data.city = document.getElementById("addAddressCity").value;
    data.mobile = document.getElementById("addAddressMobile").value;
    data.email = document.getElementById("detail-email").value;
   

    
        $.ajax({
            type: "POST",
            url: "/UserPage/AddUserAddress",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: data,
            success: function (result) {
                if (result.value == "true") {

                    
                    document.getElementById("addAddresscancel").click();
                    alert("Address Added Successfully!");

                    window.location.reload();
                    getAddress();
                }
                else {
                    alert("not saved");
                }

            },
            error: function (error) {
                alert(error);
            }

        });
    
});











var addressId;

$("#tab2").on('click', function (e) {
    var element = e.target.closest("button");

    console.log(element);
    if (element != null) {
        if (element.classList.contains("editAddress")) {
            addressId = element.getAttribute("data-value");
            console.log("editaddress");

            var data = {};
            data.addressId = addressId;

            $.ajax({
                type: 'GET',
                url: '/UserPage/EditAddressView',
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: data,
                success: function (result) {
                    if (result != false) {

                        document.getElementById("editAddressLine1").value = result.addressLine1;
                        document.getElementById("editAddressLine2").value = result.addressLine2;
                        document.getElementById("editAddressPostalCode").value = result.postalCode;
                        document.getElementById("editAddressCity").value = result.city;
                        document.getElementById("editAddressMobile").value = result.mobile;
                    }
                },
                error: function (error) {
                    alert(error);
                }
            });

            console.log(addressId);
            $("#editAddressModal").modal("show");



        }
        if (element.classList.contains("deleteAddress")) {
            console.log("delete");
            addressId = element.getAttribute("data-value");
            $("#deleteAddressModal").modal("show");
        }
    }

});










$("#editAddressUpdate").on('click', function () {


    var data = {};
    data.addressId = addressId;
    data.addressLine1 = document.getElementById("editAddressLine1").value;
    data.addressLine2 = document.getElementById("editAddressLine2").value;
    data.postalCode = document.getElementById("editAddressPostalCode").value;
    data.city = document.getElementById("editAddressCity").value;
    data.mobile = document.getElementById("editAddressMobile").value;
    data.email = document.getElementById("detail-email").value;




   
   
        $.ajax({
            type: "POST",
            url: "/UserPage/EditUserAddress",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: data,
            success: function (result) {
                if (result.value == "true") {

                    alert("Address Changes !");

                    window.setTimeout(function () {
                        $("#editAddressModal").modal("hide");
                        document.getElementsByClassName("editAddresscancel").click();
                    }, 500);

                    window.location.reload();

                    getAddress();

                }
                else {
                    alert("not saved");
                }
                

            },
            error: function (error) {
                alert(error);
            }

        });
    

});






$("#deleteUserAddress").click(function () {
    var data = {};
    data.addressId = addressId;
    $.ajax({
        type: "POST",
        url: "/UserPage/DeleteUserAddress",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result == true) {

                alert("Address Deleted !");
                $("#deleteAddressModal").modal("hide");

                getAddress();
            }
            else {
                alert("fail");
            }
        },
        error: function (error) {

        }
    });

});
















$("#changePass").on('click', function () {

    var data = {};
    data.oldPassword = document.getElementById("old-password").value;
    data.newPassword = document.getElementById("new-password").value;
    data.confirmPassword = document.getElementById("cnfrm-password").value;


    
        $.ajax({
            type: "POST",
            url: "/UserPage/ChangePassword",
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            data: data,
            success: function (result) {
                if (result.value == "true") {
                    alert("Password Changed Successfully.");
                }
                else {
                    alert("Password is wrong! Please try again.");
                }
            },
            error: function (error) {
                alert("Something went wrong! Please try again leter.");
            }
        });
    

});




function exportexcel() {
    $("#HistoryTable").table2excel({
        name: "Table2Excel",
        filename: "Customer-ServiceHistory",
        fileext: ".xls"
    });
}