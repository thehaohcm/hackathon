<template>
    <div class="create-question">
        <h2>Create a multiple-choice question</h2>
        <div>
            <div>
                <h3>Type a question</h3>
            </div>
            <div>
                <textarea id="question" cols="100%" rows="5%"></textarea>
            </div>
            <div>
                <label>Image (optional): </label>
                <input type="file" name="file" style="margin-top: 10px;">
            </div>
        </div>
        <div class="option">
            <h3>Type 4 option answers</h3>
            <ol type="A">
                <li>
                    <input id="option-1" type="radio">
                    <input id="answer-1" type="text" size="100%">
                </li>
                <li>
                    <input id="option-2" type="radio">
                    <input id="answer-2" type="text" size="100%">
                </li>
                <li>
                    <input id="option-3" type="radio">
                    <input id="answer-3" type="text" size="100%">
                </li>
                <li>
                    <input id="option-4" type="radio">
                    <input id="answer-4" type="text" size="100%">
                </li>
            </ol>
        </div>
        <div class="btn-pnl">
            <div class="cnl">
                <button>Cancel</button>
            </div>
            <div class="sbmt">
                <button>Submit</button>
            </div>
        </div>
    </div>
</template>

<script>

</script>

<style scoped>
li{
    margin-top: 10px;
}
button{
    width: 80px;
    height: 30px;
}
.btn-pnl{
    margin-top: 50px;
}
.sbmt{

}
</style>