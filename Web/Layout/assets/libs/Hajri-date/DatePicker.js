'use strict';
let picker = new Datepicker();
let pickElm = picker.getElement();
let pLeft = 150;
let pWidth = 150;
pickElm.style.position = 'absolute';
pickElm.style.left = pLeft + 'px';
pickElm.style.top = '172px';
picker.attachTo(document.body);
picker.setLanguage('ar');
picker.setWidth(200);
picker.setTheme('blue');
picker.setFirstDayOfWeek(6);
let pickerItemId = "";

picker.onPicked = function () {
    $("#" + pickerItemId + "-display").attr('value', picker.getPickedDate().getDateString());
    if (picker.getPickedDate() instanceof Date) {
        $("#" + pickerItemId).attr('value', picker.getPickedDate().getDateFormated());
    } else {
        $("#" + pickerItemId).attr('value', picker.getOppositePickedDate().getDateFormated());
    }
};

function openSidebar() {
    document.getElementById("mySidebar").style.display = "block"
}

function closeSidebar() {
    document.getElementById("mySidebar").style.display = "none"
}

function dropdown(el) {
    if (el.className.indexOf('expanded') == -1) {
        el.className = el.className.replace('collapsed', 'expanded');
    } else {
        el.className = el.className.replace('expanded', 'collapsed');
    }
}



function pickDate(ev, name, hijrDate = false) {
    ev = ev || window.event;
    let el = ev.target || ev.srcElement;
    pLeft = ev.pageX;
    fixWidth();
    pickElm.style.top = ev.pageY + 'px';
    picker.setHijriMode(hijrDate);
    picker.show();
    el.blur()
    pickerItemId = name;
}

function gotoToday() {
    picker.today()
}

function fixWidth() {
    let docWidth = document.body.offsetWidth;
    let isFixed = false;
    if (pLeft + pWidth > docWidth) pLeft = docWidth - pWidth;
    if (docWidth >= 992 && pLeft < 200) pLeft = 200;
    else if (docWidth < 992 && pLeft < 0) pLeft = 0;
    if (pLeft + pWidth > docWidth) {
        picker.setWidth(pWidth);
        document.getElementById('valWidth').value = pWidth;
        document.getElementById('sliderWidth').value = pWidth;
        isFixed = false
    }
    pickElm.style.left = pLeft - 2*pWidth + 'px';
    return isFixed
}

