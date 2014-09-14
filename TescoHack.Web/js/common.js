var app = (function () {
	return {
		getCharacterIndex: function(name) {
			return this.getCookie("char_index");
		},
		setCharacterIndex: function(index) {
			this.setCookie("char_index", index, 1);
		},
		setCookie: function(cname, cvalue) {
			var d = new Date();
			d.setTime(d.getTime() + (1*24*60*60*1000));
			var expires = "expires="+d.toUTCString();
			document.cookie = cname + "=" + cvalue + "; " + expires;
		},
		getCookie: function(cname) {
			var name = cname + "=";
			var ca = document.cookie.split(';');
			for(var i=0; i<ca.length; i++) {
				var c = ca[i];
				while (c.charAt(0)==' ') c = c.substring(1);
				if (c.indexOf(name) != -1) return c.substring(name.length, c.length);
			}
			return "";
		}
	};
})();