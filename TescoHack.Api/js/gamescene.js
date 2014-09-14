var timer = 100;

$( document ).ready(function() {

  setInterval(function(){
	if(timer > 0){
		timer = timer - 0.1;

		$('.timebar-inner').css('width', timer + '%');
	}
  }, 200);
});


function addtime(){
	timer = timer + 30;
	if(timer > 100){
		timer = 100;
	}
}
