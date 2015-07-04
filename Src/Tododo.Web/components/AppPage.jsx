/** @jsx React.DOM */

var React = require("react");

var RouterMixin = require('flux-router-component').RouterMixin;
var AppStore = require("../stores/AppStore");
var StoreMixin = require("fluxible").StoreMixin;
var ViewSelector = require("./ViewSelector");
var TopNav = require("./TopNav");
var debug = require("debug")("app");

var AppPage = React.createClass({
	mixins: [StoreMixin, RouterMixin],

	displayName : "AppPage",
	propTypes: {
		context: React.PropTypes.object.isRequired
	},
	statics: {
	},
	getInitialState: function getInitialState() {
		return this.getStateFromStores();
	},

	getStateFromStores: function getStateFromStores() {
		var appStore = this.getStore(AppStore);
		return {
			// route is required by Router Mixin
			route: appStore.getRoute()
		};
	},

	_onChange: function() {
		this.setState(this.getStateFromStores());
	},

	render: function render() {
		var context = this.props.context;
		var page = this.state.route.name;
		var params = this.state.route.params;

		return (
			<div className="container">
				<TopNav context={context} projectName="Tododo" />
				<div className="jumbotron">
					<ViewSelector context={context} page={page} params={params} />
				</div>
			</div>
		);
	}
});


module.exports = AppPage;