import Vue from 'vue'
import Router from 'vue-router'
import Welcome from '@/components/Welcome'
import Question from '@/components/Question'

Vue.use(Router)

export default new Router({
  routes: [
	{
		path: '/',
		name: 'Welcome',
		component: Welcome
	},
    {
      path: '/questions',
      name: 'Question',
      component: Question
    }
  ]
})
