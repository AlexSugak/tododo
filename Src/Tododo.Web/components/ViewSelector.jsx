/** @jsx React.DOM */

var React = require("react");

var IndexView = require("./IndexView");
var TasksView = require("./TasksView");
var EmployeesView = require("./EmployeesView");

var ViewSelector = React.createClass({
	propTypes: {
		context: React.PropTypes.object.isRequired,
		page: React.PropTypes.string.isRequired
	},

	loadView: function(page) {
		var context = this.props.context;
		if (page === "index") {
			return <IndexView context={context} />;
		}
		if (page === "tasks") {
			return <TasksView context={context} />;
		}
		if (page === "employees") {
			return <EmployeesView context={context} />;
		}

		return (<div>{page}</div>);
	},

	render: function render() {
		var view = this.loadView(this.props.page);
		return view;
	}
});


module.exports = ViewSelector;