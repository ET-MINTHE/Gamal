
function confirmAddMark(isAddChecked) {

    if (isAddChecked) {
        $('#'+'addMarkSpan').hide();
        $('#'+'confirmAddMarkSpan').show();
    } else {
        $('#'+'addMarkSpan').show();
        $('#'+'confirmAddMarkSpan').hide();
    }
}

function confirmDelete(isChecked) {

    if (isChecked) {
        $('#' + 'deleteSpan').hide();
        $('#' + 'confirmDeleteSpan').show();
    } else {
        $('#' + 'deleteSpan').show();
        $('#' + 'confirmDeleteSpan').hide();
    }
}

function confirmEnrollment(isChecked) {

    if (isChecked) {
        $('#' + 'deleteSpan').hide();
        $('#' + 'confirmDeleteSpan').show();
    } else {
        $('#' + 'deleteSpan').show();
        $('#' + 'confirmDeleteSpan').hide();
    }
}