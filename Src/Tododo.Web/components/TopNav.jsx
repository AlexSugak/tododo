﻿/** @jsx React.DOM */

var React = require("react");
var TopNavLink = require("./TopNavLink");

var TopNav = React.createClass({
	propTypes: {
		projectName: React.PropTypes.string.isRequired,
		route: React.PropTypes.string.isRequired,
		context: React.PropTypes.object.isRequired
	},

	render: function render() {
		var projectName = this.props.projectName;
		var route = this.props.route;
		var context = this.props.context;
		return (
			<nav className="navbar navbar-default">
				<div className="container-fluid">
				  <div className="navbar-header">
					<button type="button" className="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
					  <span className="sr-only">Toggle navigation</span>
					  <span className="icon-bar"></span>
					  <span className="icon-bar"></span>
					  <span className="icon-bar"></span>
					</button>
					<a className="navbar-brand" href="#">{projectName}</a>
				  </div>
				  <div id="navbar" className="navbar-collapse collapse">
					<ul className="nav navbar-nav">
						<TopNavLink title="Home" route="index" currentRoute={route} context={context} />
						<TopNavLink title="Tasks" route="tasks" currentRoute={route} context={context} />
						<TopNavLink title="Employees" route="employees" currentRoute={route} context={context} />
					</ul>
					<ul className="nav navbar-nav navbar-right">
					  <li className="active"><a href="./">One <span className="sr-only">(current)</span></a></li>
					  <li><a href="./">Two</a></li>
					</ul>
				  </div>
				</div>
			  </nav>
		);
	}
});


module.exports = TopNav;