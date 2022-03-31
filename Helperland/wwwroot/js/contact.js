$(document).ready(function () {
  $('#contact-form').submit(function (e) {
    e.preventDefault();
    var first_name = $('#first_name').val();
    var last_name = $('#last_name').val();
    var email = $('#email').val();
    var number = $('#number').val();
    $(".error").remove();
    if (first_name.length < 1) {
      $('#first_name').after('<span class="error">This field is required</span>');
    }
    if (number.length < 1) {
      $('#phone-no').after('<span class="error">This field is required</span>');
    }
    if (last_name.length < 1) {
      $('#last_name').after('<span class="error">This field is required</span>');
    }
    if (email.length < 1) {
      $('#email').after('<span class="error">This field is required</span>');
    } else {
      var regEx = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
      var validEmail = regEx.test(email);
      if (!validEmail) {
        $('#email').after('<span class="error">Enter a valid email</span>');

      }
    }

  });


});





var input = document.getElementById( 'attachment' );
var infoArea = document.getElementById( 'file-upload-filename' );

input.addEventListener( 'change', showFileName );

function showFileName( event ) {
  
  // the change event gives us the input it occurred in 
  var input = event.srcElement;
  
  // the input has an array of files in the `files` property, each one has a name that you can use. We're just using the name here.
  var fileName = input.files[0].name;
  
  // use fileName however fits your app best, i.e. add it into a div
  infoArea.textContent = 'File name: ' + fileName;
}