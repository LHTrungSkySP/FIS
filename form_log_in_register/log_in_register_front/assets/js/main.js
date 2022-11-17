// Author: Lê hoàng trung 
// date: 12/11/2022 dd-mm-yy
import * as def from "./defines.js"
import * as img from "./img_move.js"
$(document).ready(function () {
    intitEvent();
    // kiểm tra target
    // $(document).click(function(evt){
    //     debugger
    // })
})
function intitEvent(){
    img.drag_img_left_to_right("img_meomeo");
}