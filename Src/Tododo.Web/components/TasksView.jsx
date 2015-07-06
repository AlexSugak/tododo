/** @jsx React.DOM */

var React = require("react");
var TasksStore = require("../stores/TasksStore");
var StoreMixin = require("fluxible").StoreMixin;

var NewTask = require("./NewTask");


var TasksView = React.createClass({
	mixins: [StoreMixin],
	propTypes: {
		context: React.PropTypes.object.isRequired
	},
	statics: {
		storeListeners: {
			_onChange: [TasksStore]
		}
	},
	getInitialState: function getInitialState() {
		return this.getStateFromStores();
	},
	getStateFromStores: function getStateFromStores() {
		var store = this.getStore(TasksStore);
		return {
			tasks: store.getAllTasks(),
			count: store.getAllTasksCount()
		};
	},

	_onChange: function() {
		this.setState(this.getStateFromStores());
	},

	render: function render() {
		var tasks = this.state.tasks;
		var cound = this.state.count;
		var context = this.props.context;

		var items = [];
		tasks.forEach(function (i) {
			items.push(
				<li key={i.id} className="list-group-item">{i.name}</li>
			);
		});

		return (
			<div className="row">
				<div className="col-md-6">
					<ul className="list-group">
						{items}					
						<NewTask context={context} />
					</ul>
				</div>
			</div>
		);
	}
});


module.exports = TasksView;