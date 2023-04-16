// Author: Lê hoàng trung 
// date: 12/11/2022 dd-mm-yy
import * as def from "./defines.js"
import * as img from "./img_move.js"
import * as ipt from "./input.js"
$(document).ready(function () {
    intitEvent();
    // kiểm tra target
    // $(document).click(function(evt){
    //     debugger
    // })
})
function intitEvent(){
    // các sự kiện xuyên suốt trang 
    initEventStart();
    // các sự kiện với input
    initEventInput();
}
function initEventStart(){
    img.drag_img_left_to_right("img_meomeo");
}
function initEventInput(){
    ipt.togglePasswordTextBox('#inputPass','#inputHideBtn');
    console.log("b");
}
