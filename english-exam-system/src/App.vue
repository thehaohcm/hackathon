<template>
  <div class="app">
	  <Header />
	  <router-view class="panel container-custom"></router-view>
	  <Footer />
  </div>
</template>

<script>
import Header from "./components/Header.vue";
import Footer from "./components/Footer.vue";

export default {
	name: 'App',
	components:{
		Header,
		Footer
	}
}
</script>

<style scoped>
html, body { height: 100%; }
body { margin: 0; }
.app{ font-family: 'Lato', sans-serif; }

input[type=date],input[type=datetime-local],input[type=month],input[type=time] {
    -webkit-appearance: listbox
}
.h1,.h2,.h3,.h4,.h5,.h6,h1,h2,h3,h4,h5,h6 {
    margin-bottom: .5rem;
    font-weight: 500;
    line-height: 1.2
}

.h1,h1 {
    font-size: 2.5rem
}

.h2,h2 {
    font-size: 2rem
}

.h3,h3 {
    font-size: 1.75rem
}
.h4,h4 {
    font-size: 1.5rem
}

.h5,h5 {
    font-size: 1.25rem
}

.h6,h6 {
    font-size: 1rem
}

.small,small {
    font-size: 80%;
    font-weight: 400
}
.list-inline,.list-unstyled {
    padding-left: 0;
    list-style: none
}
.form-control {
    display: block;
    width: 100%;
    height: calc(1.5em + .75rem + 2px);
    padding: .375rem .75rem;
    font-size: 1rem;
    font-weight: 400;
    line-height: 1.5;
    color: #495057;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    border-radius: .25rem;
    transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out
}
@media (prefers-reduced-motion:reduce) {
    .form-control {
        transition: none
    }
}

.form-control::-ms-expand {
    background-color: transparent;
    border: 0
}

.form-control:-moz-focusring {
    color: transparent;
    text-shadow: 0 0 0 #495057
}
.form-control:focus {
    color: #495057;
    background-color: #fff;
    border-color: #80bdff;
    outline: 0;
    box-shadow: 0 0 0 .2rem rgba(0,123,255,.25)
}
.form-control::-webkit-input-placeholder {
    color: #6c757d;
    opacity: 1
}
.form-control::-moz-placeholder {
    color: #6c757d;
    opacity: 1
}

.form-control::-ms-input-placeholder {
    color: #6c757d;
    opacity: 1
}
.form-control::placeholder {
    color: #6c757d;
    opacity: 1
}
.form-group {
    margin-bottom: 1rem
}

.btn {
    display: inline-block;
    font-weight: 400;
    color: #212529;
    text-align: center;
    vertical-align: middle;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    background-color: transparent;
    border: 1px solid transparent;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: .25rem;
    transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out
}

@media (prefers-reduced-motion:reduce) {
    .btn {
        transition: none
    }
}

.btn:hover {
    color: #212529;
    text-decoration: none
}

.btn.focus,.btn:focus {
    outline: 0;
    box-shadow: 0 0 0 .2rem rgba(0,123,255,.25)
}

.btn.disabled,.btn:disabled {
    opacity: .65
}

.container-custom{
	margin-left: 80px;
    margin-right: 80px;
}

</style>
