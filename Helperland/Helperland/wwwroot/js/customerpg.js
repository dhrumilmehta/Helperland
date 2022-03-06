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


var checkTextarea = (e) => {
    const content = $("#canText").val().trim();
    $('#cancelServBtn').prop('disabled', content === '');
  };
  
  $(document).on('keyup', '#canText', checkTextarea);




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





/*

document.getElementById("RescheduleUpdateBtn").addEventListener("click", function () {
    var serviceStartDate = document.getElementById("RescheduledDate").value;
    var serviceTime = document.getElementById("RescheduledTime").value;
    var serviceRequestId = document.getElementById("updateRequestId").value;
    console.log(serviceRequestId);
    var data = {};
    data.Date = serviceStartDate;
    data.startTime = serviceTime;
    data.serviceRequestId = serviceRequestId;

    $.ajax({
        type: 'POST',
        url: '/UserPage/RescheduleServiceRequest',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
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
*/



var srId;
var serviceRequestId = "";
$(".dashbordTable").click(function (e) {


    serviceRequestId = e.target.closest("tr").getAttribute("data-value");

    if (e.target.classList == "customerReschedule") {
        document.getElementById("updateRequestId").value = e.target.value;

    }
    if (e.target.classList == "customerCancel") {
        document.getElementById("CancelRequestId").value = e.target.value;
    }
    
    console.log(e);
});

$('.customerReschedule').on('click', function () {

    document.getElementById("updateRequestId").value = srId;
});


$('.customerCancel').on('click', function () {

    document.getElementById("CancelRequestId").value = srId;
});


/*Reschedule*/


document.getElementById("RescheduleServiceRequest").addEventListener("click", function () {
    var serviceStartDate = document.getElementById("selected_date").value;
    var serviceTime = document.getElementById("selected_time").value;
    var serviceRequestId = document.getElementById("updateRequestId").value;
    console.log(serviceRequestId);
    var data = {};
    data.Date = serviceStartDate;
    data.startTime = serviceTime;
    data.serviceRequestId = serviceRequestId;

    $.ajax({
        type: 'POST',
        url: '/Customer/RescheduleServiceRequest',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
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

/*  for cancel */  /* status 1-created 2-assigned 3-complted 4-cancled  */

document.getElementById("CancelRequestBtn").addEventListener("click", function () {

    var ServiceRequestId = document.getElementById("CancelRequestId").value;
    var Comments = document.getElementById("cancelReason").value;
    var data = {};

    data.serviceRequestId = ServiceRequestId;
    data.comments = Comments;

    $.ajax({
        type: 'POST',
        url: '/Customer/CancelServiceRequest',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            if (result.value == "true") {
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




//////////

/* rating */


/*rate submit btn */

document.getElementById("confirm_rating").addEventListener("click", function () {

    var data = {};
    data.onTimeArrival = $(".infomsg").text();
    data.friendly = $(".friendlymsg").text();
    data.qualityOfService = $(".qualitymsg").text();
    data.ratings = parseFloat((parseFloat(data.onTimeArrival) + parseFloat(data.friendly) + parseFloat(data.qualityOfService)) / 3);

    data.comments = $("#feedbackcomment").val();
    data.serviceRequestId = serviceRequestId;

    $.ajax({

        type: "POST",
        url: "/Customer/RateServiceProvider",
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: data,
        success: function (result) {
            if (result.value == "true") {
                $("#myRatingModal").modal("hide");
                console.log("submited");

            }
            else {
                alert("you have alredy given rating ");
            }
        },
        error: function (error) {
            alert("error");
        }

    });


});



/*get rating from db */



$(document).on('click', '.rateactive', function () {

    var data = {};
    data.ServiceRequestId = parseInt(serviceRequestId);
    $.ajax({
        type: 'GET',
        url: '/customer/GetRating',
        contenttype: 'application/x-www-form-urlencoded; charset=utf-8',
        data: data,
        success: function (result) {
            if (result == null) {
                document.getElementById("show_rating_model").className = "d-none";

            } else {
                document.getElementById("show_rating_model").className = "show_rating_model";
                var rating = parseInt(result.averageRating);
                $('.star-ratingmodel').html("");

                var rat = round(result.averageRating);
                alert(rat);
                $('.service-provider-ratingmodel').html(result.serviceProvider);
                $("#show_rating_model img.spavtar").attr("src", result.userProfilePicture);
                for (var i = 0; i < 5; i++) {
                    if (i < rating) {
                        $('.star-ratingmodel').append('<i class="fa fa-star " style="color:#ECB91C;" ></i>');
                    } else {
                        $('.star-ratingmodel').append('<i class="fa fa-star " style="color:silver;"></i>');
                    }
                }
                $('.star-ratingmodel').append(result.averageRating);
            }
        },
        error: function () {
            alert('failed to receive the data');
            console.log('failed ');
        }
    });
});


////////
/*----------------  for my settings js -----------      */


/* code for year in settings */

$(document).ready(function () {
    var currentYear = (new Date()).getFullYear();

    $('#dobyear').append(' <option value="0000">Year</option> ');
    for (var i = 1950; i <= (currentYear); i++) {
        var option = $("<option />");
        option.html(i);
        option.val(i);
        $('#dobyear').append(option);
    }
});


/* get data for user from db */


$(document).ready(function () {


    $.ajax({
        type: 'GET',
        url: '/Customer/GetCustomerData',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',

        success: function (result) {





            var MSfirstname = document.getElementById("mSfirstname");
            var MSlastname = document.getElementById("mSlastname");
            var MSemail = document.getElementById("mSemailaddress");
            var Msphoneno = document.getElementById("mSphonenumber");

            MSfirstname.value = result.firstName;
            MSlastname.value = result.lastName;
            MSemail.value = result.email;
            Msphoneno.value = result.mobile;


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





$("#CSSaveDetails").on('click', function () {



    var data = {};
    data.firstName = document.getElementById("mSfirstname").value;
    data.lastName = document.getElementById("mSlastname").value;
    data.email = document.getElementById("mSemailaddress").value;
    data.mobile = document.getElementById("mSphonenumber").value;
    data.dateOfBirth = $("#dobday").val() + "-" + $("#dobmonth").val() + "-" + $("#dobyear").val();

    console.log(data.dateOfBirth);
    window.setTimeout(function () {
        $('#mSmyDetailsAlert').addClass('d-none');
    }, 5000);

    if (data.firstName == "") {
        $("#mSmyDetailsAlert").removeClass("alert-success d-none").addClass("alert-danger").text("Firstname is Required.");
        $("#mSfirstname").focus();
    }
    else if (data.lastName == "") {
        $("#mSmyDetailsAlert").removeClass("alert-success d-none").addClass("alert-danger").text("Lastname is Required.");
        $("#mSlastname").focus();
    }
    else if (data.mobile == "") {
        $("#mSmyDetailsAlert").removeClass("alert-success d-none").addClass("alert-danger").text("Mobile is Required.");
        $("#mSphonenumber").focus();
    }

    else if ($("#dobday").val() == 00 || $("#dobmonth").val() == 00 || $("#dobyear").val() == 0000) {
        $("#mSmyDetailsAlert").removeClass("alert-success d-none").addClass("alert-danger").text("select valid birthdate.");

    }
    else {
        $.ajax({
            type: 'POST',
            url: '/Customer/UpdateCustomerData',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            data: data,
            success: function (result) {
                if (result.value == "true") {
                    $("#mSmyDetailsAlert").removeClass("alert-danger d-none").addClass("alert-success").text("User is updated.");
                    window.setTimeout(function () {
                        window.location.reload();
                    }, 2000);

                }
                else {
                    $("#mSmyDetailsAlert").removeClass("alert-success d-none").addClass("alert-danger").text("Something went wrong! please try again later.");
                }
            },
            error: function () {
                alert("error");
            }
        });
    }

});