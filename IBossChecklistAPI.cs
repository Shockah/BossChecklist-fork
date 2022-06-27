using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace BossChecklist
{
	// this is the interface the consuming mods would copy-paste to their code. any methods that aren't used by them can (and probably should) be omitted
	// (regarding "should": if Boss Checklist was to remove one of the methods, its API would be inaccessible by mods using those methods - unless Pintail is configured in a different way)
	public interface IBossChecklistAPI
	{
		#region simple example 1:1 with the Mod.Call

		void AddBoss(Mod source, string name, List<int> ids, float progress, Func<bool> down, Func<bool> available, List<int> collect, List<int> spawn, string info, Func<NPC, string> despawn = null, Action<SpriteBatch, Rectangle, Color> drawing = null);

		#endregion

		#region a more advanced example, allowing for subclassing

		// unfortunately since its an interface, we can't really ensure that the values won't change
		public interface IBossDefinition
		{
			// those shouldn't change
			Mod Source { get; }
			string Name { get; }
			List<int> IDs { get; }
			float Progress { get; }
			List<int> Collection { get; }
			List<int> SpawnItems { get; }
			string SpawnInfo { get; }

			// these can change freely
			bool IsDowned { get; }
			bool IsAvailable { get; }

			// honestly couldn't think of a better way of doing the rest, without changing the internal implementations (i just want to make a simple example, maaan)

			bool UsesCustomDespawnMessage { get; }
			string GetDespawnMessage(NPC npc) => null;

			bool DoesCustomDrawing { get; }
			void Draw(SpriteBatch spriteBatch, Rectangle rectangle, Color color) { }
		}

		void AddBoss(IBossDefinition definition);

		#endregion
	}
}