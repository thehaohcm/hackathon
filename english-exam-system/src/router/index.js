import Vue from 'vue'
import Router from 'vue-router'
import Welcome from '@/components/Welcome'
import Question from '@/components/Question'
import Review from '@/components/Review'
import Result from '@/components/Result'
import InputInfo from '@/components/InputInfo'
import Finished from '@/components/Finished'

Vue.use(Router)

export default new Router({
	mode: 'history',
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
		},
		{
			path: '/review',
			name: 'Review',
			component: Review
		},
		{
			path: '/result',
			name: 'Result',
			component: Result
		},
		{
			path: '/finished',
			name: 'Finished',
			component: Finished
		},
		{
			path: '/input',
			name: 'InputInfo',
			component: InputInfo
		},
	]
})
