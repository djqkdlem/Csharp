<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Vuejs.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery.min.js"></script>
    <script src="js/vue.js"></script>
    <link href="css/animate.css" rel="stylesheet" />
</head>
<body>
    <style>
        .ticket {
            border: 2px solid gray;
            width: 200px;
            margin-bottom: 50px;
        }
    </style>
        <div v-for="(index, value) in storyList">
        <div class="ticket">
            <div style="background: #9c9cde">
                <div @click="openPopup($index)">...</div>
            </div>
            <div style="background: #000000">
                <div style="color: #FFFFFF">
                    별, 정보, 체크
                </div>
            </div>
            <div  @click="openPopup(index)">
                [복리후생] 스포츠관람 신청
            </div>
            <div class="ticketBody{{index}}" v-if="showModal[index].value"  @click="closePopup(index)">
                신청 - 최시연(2016.06.27 오전 11:45) 진행중- 박규선(2016.06.27 오전 11:45)
            </div>
            <input v-model="txt[index]" />
            <p>{{txt[index]}}</p>
        </div>
    </div>
     
    <script type="text/javascript">
       
        var modal;
        $(function () {

            $.fn.extend({
                animateCss: function (animationName) {
                    var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
                    this.addClass('animated ' + animationName).one(animationEnd, function () {
                        $(this).removeClass('animated ' + animationName);
                    });
                }
            });
            // start app
            modal = new Vue({
                el: 'body',
                data: {
                    showModal: [{ value: true }, { value: false }, { value: false }, { value: false }, { value: false }],
                    storyList: ['a', 'b', 'c', 'd', 'e'],
                    txt: [],
                    show: true

                },
                methods: {
                    closePopup: function (index) {
                        this.showModal[index].value = false;
                        $('.ticketBody' + index).animateCss('bounce');
                    },
                    openPopup: function (index) {
                        this.showModal[index].value = true;
                        $('.ticketBody' + index).animateCss('bounce');
                    }
                }
            })

        });
    </script>
</body>
</html>



