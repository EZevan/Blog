var func = window.func || {}

var func = {
    getLocalStorage: function(name){
        return localStorage.getItem(name);
    },
    
    setLocalStorage: function(name,value){
        localStorage.setItem(name,value);
    },
    
    switchTheme: function(){
        let currentTheme = this.getLocalStorage("theme") || "Light";
        let isDarkTheme = currentTheme === "Dark";
        
        if(isDarkTheme){
            document.querySelector("body").classList.add("dark-theme");
        }
        else{
            document.querySelector("body").classList.remove("dark-theme");
        }
    }
}