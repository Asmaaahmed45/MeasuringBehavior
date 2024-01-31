var selectedValues = [];
function saveSelectedValue(currentPage) {

    var radioButtons = document.getElementsByName('radio');
    for (var i = 0; i < radioButtons.length; i++) {
        if (radioButtons[i].checked) {
            var selectedValue = radioButtons[i].value;
            localStorage.setItem(currentPage, selectedValue);
            break; 
        }
    }
}

window.onload = function () {
   
    var localStorageKeys = Object.keys(localStorage);
    localStorageKeys.forEach(function (key) {
        var value = localStorage.getItem(key);
        selectedValues.push(value);
    });

    var radioButtons = document.getElementsByName('radio');
    for (var i = 0; i < radioButtons.length; i++) {
        if (selectedValues.includes(radioButtons[i].value)) {
            radioButtons[i].checked = true;
        }
    }
};

function SendPostRequest() {
    return $.ajax({
        type: "POST", 
        url: '/Question/CalculateScore', 
        data: JSON.stringify(selectedValues),
        contentType: 'application/json',
        success: function (data) {
            window.location.href = '/Question/ScoreView';
        },
    });
}
function DisableQuestionsBtn() {
    localStorage.setItem('buttonDisable', 'true');
}

