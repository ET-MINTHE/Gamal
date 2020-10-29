
function confirmAddMark(isAddChecked) {

    if (isAddChecked) {
        $('#'+'addMarkSpan').hide();
        $('#'+'confirmAddMarkSpan').show();
    } else {
        $('#'+'addMarkSpan').show();
        $('#'+'confirmAddMarkSpan').hide();
    }
}

function confirmDelete(uniqueId, isChecked) {

    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;
    if (isChecked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
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