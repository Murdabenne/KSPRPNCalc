﻿// This file is part of KerbalRPNCalc.
// 
// KerbalRPNCalc is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// KerbalRPNCalc is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with KerbalRPNCalc. If not, see <http://www.gnu.org/licenses/>.

using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace PartsAPI.Engine
{
    internal class EngineFactory
    {
        internal static Engine Normalise(ModuleEngines engine)
        {
            return Engine.CreateEngineWithName(Part.FromGO(engine.gameObject).partInfo.title)
                .WithMode(x =>
                {
                    x.SeaLevelISP = engine.atmosphereCurve.Evaluate(1.0f);
                    x.VacuumISP = engine.atmosphereCurve.Evaluate(0.0f);
                });
        }

        internal static Engine Normalise(ModuleEnginesFX engine)
        {
            return Engine.CreateEngineWithName(Part.FromGO(engine.gameObject).partInfo.title)
                .WithMode(x =>
                {
                    x.SeaLevelISP = engine.atmosphereCurve.Evaluate(1.0f);
                    x.VacuumISP = engine.atmosphereCurve.Evaluate(0.0f);
                });
        }

        internal static Engine Normalise(MultiModeEngine engine)
        {
            var engines = Resources.FindObjectsOfTypeAll<ModuleEnginesFX>()
                .Where(e => e.engineID == engine.primaryEngineID || e.engineID == engine.secondaryEngineID);

            var builder = Engine.CreateEngineWithName(Part.FromGO(engine.gameObject).partInfo.title);

            return engines.Aggregate(builder, (current, engineMode) => current.WithMode(mode =>
            {
                mode.Name = Regex.Replace(engineMode.engineID, "([a-z])([A-Z])", "$1 $2");
                mode.SeaLevelISP = engineMode.atmosphereCurve.Evaluate(1.0f);
                mode.VacuumISP = engineMode.atmosphereCurve.Evaluate(0.0f);
            }));
        }
    }
}