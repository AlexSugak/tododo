/** @jsx React.DOM */

var React = require("react");

var IndexView = require("./IndexView");
var TasksView = require("./TasksView");
var TaskDetailsView = require("./TaskDetailsView");
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
		if (page === "task") {
			var taskId = this.props.params.taskId;
			if (taskId === undefined) {
				throw new Error("Task Id must be specified");
			}
			return <TaskDetailsView context={context} taskId={taskId} />;
		}
		if (page === "employees") {
			return <EmployeesView context={context} />;
		}

		return (<div>[{page}] page not found</div>);
	},

	render: function render() {
		var view = this.loadView(this.props.page);
		return view;
	}
});


module.exports = ViewSelector;