
function confirmAddMark(isAddChecked) {

    if (isAddChecked) {
        $('#'+'addMarkSpan').hide();
        $('#'+'confirmAddMarkSpan').show();
    } else {
        $('#'+'addMarkSpan').show();
        $('#'+'confirmAddMarkSpan').hide();
    }
}

