$(document).ready(function(){
  //character counter for about me
  var text_max = 250;
  $('#count_message').html(text_max + ' remaining');
  $('#text').keyup(function() {
    var text_length = $('#text').val().length;
    var text_remaining = text_max - text_length;
    $('#count_message').html(text_remaining + ' remaining');
  });
  //delete profile button
  $('#delete').click(function(event){
    event.preventDefault();
    $(".hidden-button").show();
    $("#delete").hide();
  });


});
